using System;
using System.Security.Cryptography;

using Amazon.KeyManagementService;

namespace IDL.Security.Cryptography.Aws
{
    public class AwsStringProtectorConfiguration
    {
        public Func<Aes> CreateAesSymmetricAlgorithm { get; set; }

        public Func<IAmazonKeyManagementService> CreateKeyManagementService { get; set; }

        public string EncryptionKeyArn { get; set; }
    }
}