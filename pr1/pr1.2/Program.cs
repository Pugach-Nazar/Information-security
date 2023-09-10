using System.Security.Cryptography;

namespace pr1._2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Стійка послідовність!");
            var rndNumberGenerator = new RNGCryptoServiceProvider();
            var randomNumber = new byte[8];
            rndNumberGenerator.GetBytes(randomNumber);
            for (int i = 0; i < 10; i++)
            {
                rndNumberGenerator.GetBytes(randomNumber);
                Console.WriteLine(Convert.ToBase64String(randomNumber));
            }
        }
    }
}