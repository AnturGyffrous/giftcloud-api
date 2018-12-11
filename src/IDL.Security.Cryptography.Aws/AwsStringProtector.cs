using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace IDL.Security.Cryptography.Aws
{
    public class AwsStringProtector : IStringProtector
    {
        private const int DeriveBytesIterations = 1;

        private const int SaltLengthInBytes = 32;

        private readonly AwsStringProtectorConfiguration _configuration;

        private readonly string _keyId;

        private readonly Lazy<Task<GenerateDataKeyResponse>> _dataKey;

        public AwsStringProtector(AwsStringProtectorConfiguration configuration)
        {
            _configuration = configuration;
            _keyId = configuration.EncryptionKeyArn;
            _dataKey = new Lazy<Task<GenerateDataKeyResponse>>(GenerateDataKeyAsync);
        }

        private Task<GenerateDataKeyResponse> DataKeyAsync => _dataKey.Value;

        private Dictionary<string, byte[]> SessionKeys { get; } = new Dictionary<string, byte[]>();

        public async Task<string> ProtectAsync(string value, params string[] purposes)
        {
            var output = new string[4];
            output[0] = Convert.ToBase64String((await DataKeyAsync).CiphertextBlob.ToArray());

            if (purposes == null || purposes.Length == 0)
            {
                purposes = new[] { "" };
            }

            var (salt, key) = await GenerateKeyAsync(purposes);

            output[1] = Convert.ToBase64String(salt);

            using (var algorithm = _configuration.CreateAesSymmetricAlgorithm())
            {
                algorithm.Key = key;
                algorithm.Mode = CipherMode.CBC;
                output[2] = Convert.ToBase64String(algorithm.IV);
                Debug.Print(output[2]);
                using (var encryptedData = new MemoryStream())
                {
                    using (var writer = new StreamWriter(new CryptoStream(encryptedData, algorithm.CreateEncryptor(), CryptoStreamMode.Write)))
                    {
                        await writer.WriteAsync(value);
                    }

                    output[3] = Convert.ToBase64String(encryptedData.ToArray());
                }
            }

            return string.Join('.', output);
        }

        public async Task<string> UnprotectAsync(string value, params string[] purposes)
        {
            var input = value.Split('.');

            if (purposes == null || purposes.Length == 0)
            {
                purposes = new[] { "" };
            }

            using (var algorithm = _configuration.CreateAesSymmetricAlgorithm())
            {
                algorithm.Key = await DecryptDataKeyAsync(input[0], input[1], purposes);
                algorithm.IV = Convert.FromBase64String(input[2]);
                using (var encryptedData = new MemoryStream(Convert.FromBase64String(input[3])))
                {
                    using (var reader = new StreamReader(new CryptoStream(encryptedData, algorithm.CreateDecryptor(), CryptoStreamMode.Read)))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }

        private async Task<byte[]> DecryptDataKeyAsync(string ciphertextKey, string salt, string[] purposes)
        {
            if (!SessionKeys.TryGetValue(ciphertextKey, out var dataKey))
            {
                using (var keyManagementService = _configuration.CreateKeyManagementService())
                {
                    var decryptedData = await keyManagementService.DecryptAsync(new DecryptRequest
                        {CiphertextBlob = new MemoryStream(Convert.FromBase64String(ciphertextKey))});
                    dataKey = decryptedData.Plaintext.ToArray();
                    SessionKeys.Add(ciphertextKey, dataKey);
                }
            }

            using (var deriveBytes = new Rfc2898DeriveBytes(string.Join('.', purposes), Convert.FromBase64String(salt), DeriveBytesIterations))
            {
                var derivedBytes = deriveBytes.GetBytes(dataKey.Length);
                for (var i = 0; i < dataKey.Length; i++)
                {
                    dataKey[i] ^= derivedBytes[i];
                }
            }

            return dataKey;
        }

        private async Task<(byte[] Salt, byte[] Key)> GenerateKeyAsync(string[] purposes)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(string.Join('.', purposes), SaltLengthInBytes, DeriveBytesIterations))
            {
                var dataKey = (await DataKeyAsync).Plaintext.ToArray();
                var derivedBytes = deriveBytes.GetBytes(dataKey.Length);
                for (var i = 0; i < dataKey.Length; i++)
                {
                    dataKey[i] ^= derivedBytes[i];
                }

                return (deriveBytes.Salt, dataKey);
            }
        }

        private async Task<GenerateDataKeyResponse> GenerateDataKeyAsync()
        {
            using (var keyManagementService = _configuration.CreateKeyManagementService())
            {
                var dataKey = await keyManagementService.GenerateDataKeyAsync(new GenerateDataKeyRequest { KeyId = _keyId, KeySpec = DataKeySpec.AES_256 });

                SessionKeys.Add(Convert.ToBase64String(dataKey.CiphertextBlob.ToArray()), dataKey.Plaintext.ToArray());

                return dataKey;
            }
        }
    }
}
