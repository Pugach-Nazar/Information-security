using System.Security.Cryptography;

namespace pr1._2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rndNumberGenerator = new RNGCryptoServiceProvider();
            var randomNumber = new byte[16];
            rndNumberGenerator.GetBytes(randomNumber);
            for (int i = 0; i < 10; i++)
            {
                rndNumberGenerator.GetBytes(randomNumber);
                Console.WriteLine(Convert.ToBase64String(randomNumber));
            }
        }
    }
}