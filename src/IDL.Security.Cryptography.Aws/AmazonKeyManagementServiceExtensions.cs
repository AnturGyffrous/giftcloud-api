using System.Threading.Tasks;
using Amazon.KeyManagementService;

namespace IDL.Security.Cryptography.Aws
{
    public static class AmazonKeyManagementServiceExtensions
    {
        public static async Task<string> DecryptAsync(this string value, IAmazonKeyManagementService keyManagementService)
        {

        }
    }
}