using System.IO;
using System.Text;
using System.Threading;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;

namespace IDL.Security.Cryptography.Aws.Tests
{
    public class AmazonKeyManagementServiceExtensionsTests
    {
        private readonly IFixture _fixture;

        public AmazonKeyManagementServiceExtensionsTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _fixture.Freeze<Mock<IAmazonKeyManagementService>>()
                .Setup(x => x.DecryptAsync(It.IsAny<DecryptRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DecryptResponse { Plaintext = new MemoryStream(Encoding.UTF8.GetBytes("Decrypted Value")) });
        }
    }
}