using EmployeeMangmentAPI.Helper;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class EncryptionHelper: IEncryptionHelper
{
    private readonly IConfiguration _configuration;
    public EncryptionHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private static readonly string Key = "YourSecureKey1234567890123456"; // 32-byte key
    private static readonly string IV = "YourSecureIV1234"; // 16-byte IV
    

    // Encrypt data
    public string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = GetValidKey(_configuration["Encryption:Key"], 32); // 32 bytes for AES-256
            aes.IV = GetValidIV(_configuration["Encryption:IV"]);       // 16 bytes for IV

            using (var encryptor = aes.CreateEncryptor())
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    // Decrypt data
    public string Decrypt(string cipherText)
        {
        using (Aes aes = Aes.Create())
        {
            // Ensure key and IV meet the AES requirements
            aes.Key = GetValidKey(_configuration["Encryption:Key"], 32); // 32 bytes for AES-256
            aes.IV = GetValidIV(_configuration["Encryption:IV"]);       // 16 bytes for IV

            using (var decryptor = aes.CreateDecryptor())
            using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

    private byte[] GetValidKey(string key, int length)
    {
        return Encoding.UTF8.GetBytes(key.PadRight(length, '0').Substring(0, length));
    }

    private byte[] GetValidIV(string iv)
    {
        return Encoding.UTF8.GetBytes(iv.PadRight(16, '0').Substring(0, 16));
    }

}
