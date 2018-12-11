using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using FluentAssertions;

using IDL.Security.Cryptography;

using Xunit;

namespace IDL.Security.Tests.Cryptography
{
    public class CryptographyExtensionsTests
    {
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashByteArrayUsingMD5()
        {
            // Arrange
            var byteArray = new byte[] { 97, 98, 99 }; // abc

            // Act
            var hash = byteArray.ComputeHash(MD5.Create());

            // Assert
            hash.ToHex().Should().Be("900150983cd24fb0d6963f7d28e17f72");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashStreamUsingSHA384()
        {
            // Arrange
            var stream = new MemoryStream(new byte[] { 97, 98, 99 }) { Position = 0 }; // abc

            // Act
            var hash = stream.ComputeHash(SHA384.Create());

            // Assert
            hash.ToHex().Should().Be("cb00753f45a35e8bb5a03d699ac65007272c32ab0eded1631a8b605a43ff5bed8086072ba1e7cc2358baeca134c825a7");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashStringBuilderUsingSHA1()
        {
            // Arrange
            var builder = new StringBuilder();
            builder.Append('a');
            builder.Append('b');
            builder.Append('c');

            // Act
            var hash = builder.ComputeHash(SHA1.Create());

            // Assert
            hash.ToHex().Should().Be("a9993e364706816aba3e25717850c26c9cd0d89d");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashStringBuilderUsingUTF32AndSHA512()
        {
            // Arrange
            var builder = new StringBuilder();
            builder.Append('a');
            builder.Append('b');
            builder.Append('c');

            // Act
            var hash = builder.ComputeHash(SHA512.Create(), Encoding.UTF32);

            // Assert
            hash.ToHex().Should().Be("93778b5235b9e2f4c91ec4c4209947c6aca2efc0f79fb060dda38d9f69881c5f50ded4209d02912bab1dac6f90c16cf56f578f91d437d8b78e63e59d0a4198a9");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashStringUsingSHA256()
        {
            // Arrange
            var value = "abc";

            // Act
            var hash = value.ComputeHash(SHA256.Create());

            // Assert
            hash.ToHex().Should().Be("ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeHashCanHashStringUsingUTF7AndSHA1()
        {
            // Arrange
            var value = "abc";

            // Act
            var hash = value.ComputeHash(SHA1.Create(), Encoding.UTF7);

            // Assert
            hash.ToHex().Should().Be("a9993e364706816aba3e25717850c26c9cd0d89d");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashByteArrayUsingHMACMD5()
        {
            // Arrange
            var value = new byte[] { 97, 98, 99 }; // abc

            // Act
            var hash = value.ComputeKeyedHash(new HMACMD5(), new byte[] { 1, 2, 3, 4 });

            // Assert
            hash.ToHex().Should().Be("fb326fc2c89c6cf0551292583cc8c7b9");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashStreamUsingHMACSHA384()
        {
            // Arrange
            var stream = new MemoryStream(new byte[] { 97, 98, 99 }) { Position = 0 }; // abc

            // Act
            var hash = stream.ComputeKeyedHash(new HMACSHA384(), new byte[] { 1, 2, 3, 4 });

            // Assert
            hash.ToHex().Should().Be("2f5050450ebcd9e11e0c94d84f40f400ff8d979aedfebc77cedd4a83827636f087177cef7037455cf500eba648a07755");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashStringBuilderUsingHMACSHA1()
        {
            // Arrange
            var builder = new StringBuilder();
            builder.Append('a');
            builder.Append('b');
            builder.Append('c');

            // Act
            var hash = builder.ComputeKeyedHash(new HMACSHA1(), new byte[] { 1, 2, 3, 4 });

            // Assert
            hash.ToHex().Should().Be("ce1299b1ca414f4e747b10f91946d3f842ceff2c");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashStringBuilderUsingUnicodeAndHMACSHA256()
        {
            // Arrange
            var builder = new StringBuilder();
            builder.Append('a');
            builder.Append('b');
            builder.Append('c');

            // Act
            var hash = builder.ComputeKeyedHash(new HMACSHA256(), Convert.FromBase64String("Zd8bJ/9rQB1E2++RXkwCI8WFQs5yMH6X"), Encoding.Unicode);

            // Assert
            hash.ToHex().Should().Be("bf25dc6cf02520589b54f52dfbc002a498084c529d514d5fd17630be2c1014be");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashStringUsingASCIIAndHMACSHA1()
        {
            // Arrange
            var value = "abc";

            // Act
            var hash = value.ComputeKeyedHash(new HMACSHA1(), new byte[] { 1, 2, 3, 4 }, Encoding.ASCII);

            // Assert
            hash.ToHex().Should().Be("ce1299b1ca414f4e747b10f91946d3f842ceff2c");
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void ComputeKeyedHashCanHashStringUsingHMACSHA256()
        {
            // Arrange
            var value = "abc";

            // Act
            var hash = value.ComputeKeyedHash(new HMACSHA256(), new byte[] { 1, 2, 3, 4 });

            // Assert
            hash.ToHex().Should().Be("d7f609a8eef8a37d9836b02a5fe12241985aa39b3e8dd28665cd46c7a7de3be3");
        }

        [Fact]
        public void ToHexWillConvertByteArrayToStringRepresentingLowercaseHexStream()
        {
            // Arrange
            var byteArray = new byte[] { 0xD9, 0x4A, 0xC4, 0xA3, 0x67, 0x44, 0x82, 0x4E };

            // Act
            var result = byteArray.ToHex();

            // Assert
            result.Should().Be("d94ac4a36744824e");
        }

        [Fact]
        public void ToHexWillConvertByteArrayToStringRepresentingLowercaseHexStreamsingTransform()
        {
            // Arrange
            var byteArray = new byte[] { 0xD9, 0x4A, 0xC4, 0xA3, 0x67, 0x44, 0x82, 0x4E };

            // Act
            var result = byteArray.ToHex(x => x.ToLower());

            // Assert
            result.Should().Be("d94ac4a36744824e");
        }

        [Fact]
        public void ToHexWillConvertByteArrayToStringRepresentingUppercaseHexStreamUsingTransform()
        {
            // Arrange
            var byteArray = new byte[] { 0xD9, 0x4A, 0xC4, 0xA3, 0x67, 0x44, 0x82, 0x4E };

            // Act
            var result = byteArray.ToHex(x => x.ToUpper());

            // Assert
            result.Should().Be("D94AC4A36744824E");
        }
    }
}
