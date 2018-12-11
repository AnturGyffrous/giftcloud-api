using System.Threading.Tasks;

namespace IDL.Security.Cryptography
{
    public interface IStringProtector
    {
        Task<string> ProtectAsync(string value, params string[] purposes);

        Task<string> UnprotectAsync(string value, params string[] purposes);
    }
}