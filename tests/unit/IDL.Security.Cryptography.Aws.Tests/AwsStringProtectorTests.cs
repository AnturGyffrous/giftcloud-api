using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

using AutoFixture;
using AutoFixture.AutoMoq;

using FluentAssertions;

using Moq;

using Xunit;

namespace IDL.Security.Cryptography.Aws.Tests
{
    public class AwsStringProtectorTests
    {
        private readonly IFixture _fixture;

        private const string SecretMessage = "This is a secret message intended for your eyes only, destroy after reading! Message reads \"THE EAGLE FLIES AT MIDNIGHT STOP\"";

        public AwsStringProtectorTests()
        {
            const string encryptionKeyArn = "arn:aws:kms:123456:key";

            var plaintextKeyBytes = Encoding.UTF8.GetBytes("Plaintext version of a data key.");
            var ciphertextKeyBytes = Encoding.UTF8.GetBytes("Ciphertext version of the data key encrypted using the AWS master key.");

            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _fixture.Register(
                () => new GenerateDataKeyResponse
                {
                    Plaintext = new MemoryStream(plaintextKeyBytes),
                    CiphertextBlob = new MemoryStream(ciphertextKeyBytes)
                });

            var keyManagementService = _fixture.Freeze<Mock<IAmazonKeyManagementService>>();
            keyManagementService
                .Setup(x => x.GenerateDataKeyAsync(It.Is<GenerateDataKeyRequest>(r => r.KeyId == encryptionKeyArn && r.KeySpec == DataKeySpec.AES_256), It.IsAny<CancellationToken>()))
                .ReturnsUsingFixture(_fixture);
            keyManagementService
                .Setup(x => x.DecryptAsync(It.Is<DecryptRequest>(r => r.CiphertextBlob.ToArray().SequenceEqual(ciphertextKeyBytes)), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DecryptResponse { Plaintext = new MemoryStream(plaintextKeyBytes) });

            _fixture.Inject(new AwsStringProtectorConfiguration
            {
                CreateAesSymmetricAlgorithm = () => new AesManaged(),
                CreateKeyManagementService = _fixture.Create<IAmazonKeyManagementService>,
                EncryptionKeyArn = encryptionKeyArn
            });

            _fixture.Register<IStringProtector>(() => _fixture.Create<AwsStringProtector>());
        }

        [Fact]
        public async Task ProtectAsyncWillEncryptStringWhenMultiplePurposesAreProvided()
        {
            // Arrange
            var sut = _fixture.Create<IStringProtector>();

            // Act
            var result = await sut.ProtectAsync(SecretMessage, "purpose 1", "purpose 2");

            // Assert
            result.Should().Contain(".");
            result.Split('.').Should().HaveCount(4);
        }

        [Fact]
        public async Task ProtectAsyncWillOnlyGenerateDataKeyOnce()
        {
            // Arrange
            var sut = _fixture.Create<IStringProtector>();

            // Act
            await sut.ProtectAsync(SecretMessage);
            await sut.ProtectAsync(SecretMessage);

            // Assert
            _fixture.Create<Mock<IAmazonKeyManagementService>>()
                .Verify(x => x.GenerateDataKeyAsync(It.IsAny<GenerateDataKeyRequest>(), It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        [Fact]
        public async Task ProtectAsyncWillEncryptStringWhenNoPurposesAreProvided()
        {
            // Arrange
            var sut = _fixture.Create<IStringProtector>();

            // Act
            var result = await sut.ProtectAsync(SecretMessage);

            // Assert
            result.Should().Contain(".");
            result.Split('.').Should().HaveCount(4);
        }

        [Fact]
        public async Task ProtectAsyncWillEncryptEmptyStringWhenNoPurposesAreProvided()
        {
            // Arrange
            var sut = _fixture.Create<IStringProtector>();

            // Act
            var result = await sut.ProtectAsync(string.Empty);

            // Assert
            result.Should().Contain(".");
            result.Split('.').Should().HaveCount(4);
        }

        [Fact]
        public async Task UnprotectAsyncWillDecryptStringWhenNoPurposesAreProvided()
        {
            // Arrange
            const string encryptedString =
                "Q2lwaGVydGV4dCB2ZXJzaW9uIG9mIHRoZSBkYXRhIGtleSBlbmNyeXB0ZWQgdXNpbmcgdGhlIEFXUyBtYXN0ZXIga2V5Lg==.Cus0AuC9fwAqqTZiE5Eo8e/b0khuecvNHWw2IIycQhc=.bc2Hoe+nA5FMET33Jgp0QA==.K1pxj+b1Wl29xH4cITRPXp2okBuCSk374ajZlK5onEkEu4dKCBE/phQr8HhG9CmZW0+jJTsT5zKRrp85QqZltIywvLvPh4Gb0yblkSHp6/ICWLToUGpDKn7eAAcagvUVY/N7MOmvH15d07BC5vnGxsPVDm0VickN7xgg8HtAk+E=";

            var sut = _fixture.Create<IStringProtector>();

            // Act
            var result = await sut.UnprotectAsync(encryptedString);

            // Assert
            result.Should().Be(SecretMessage);
        }

        [Fact]
        public async Task UnprotectAsyncWillDecryptStringWhenMultiplePurposesAreProvided()
        {
            // Arrange
            const string encryptedString =
                "Q2lwaGVydGV4dCB2ZXJzaW9uIG9mIHRoZSBkYXRhIGtleSBlbmNyeXB0ZWQgdXNpbmcgdGhlIEFXUyBtYXN0ZXIga2V5Lg==.lZ03l0ZN3Hz9gubPwk2aIEdffQqkYlClhpCj8exdQZc=.Cri1npy6bqKm4SuD2SYACQ==.2ney4LGzLzbQQITgZLFqRyjyk5DCS41ZB8freIA6NvgCxZpvIYTgjZr1JO0RwfGrmlZiLK9uaWm5IFO0BHFl2RIV1w1J6pT88MlNY4L3hF8mZfgd+MjHh+PlRX+XZaH4Z47HWVPh8QeAmtVgQAuEW6R/a1u12GIItAaLLQb7mt0=";

            var sut = _fixture.Create<IStringProtector>();

            // Act
            var result = await sut.UnprotectAsync(encryptedString, "purpose 1", "purpose 2");

            // Assert
            result.Should().Be(SecretMessage);
        }
    }
}
