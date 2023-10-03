using System.Security.Cryptography;
using System.Text;

namespace lab3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rndNumberGenerator = new RNGCryptoServiceProvider();
            byte[] key = new byte[16];
            rndNumberGenerator.GetBytes(key);
            string data = "Some data";
            Console.WriteLine(Convert.ToBase64String(ComputeHmac(data, key)));
            Console.WriteLine(Convert.ToBase64String(ComputeHmac(data, key)));

            rndNumberGenerator.GetBytes(key);
            Console.WriteLine("new key");

            Console.WriteLine(Convert.ToBase64String(ComputeHmac(data, key)));
            Console.WriteLine(Convert.ToBase64String(ComputeHmac(data, key)));
        }

        static byte[] ComputeHash(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var hash = SHA1.Create())
            {
                return hash.ComputeHash(bData);
            }
        }
        static byte[] ComputeHmac(string data, byte[] key)
        {
            byte[] hash = ComputeHash(data);
            var hmac = new HMACSHA512(key);
            return hmac.ComputeHash(hash);
        }
    }
}