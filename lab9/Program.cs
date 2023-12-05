using System;
using System.Security.Cryptography.X509Certificates;

namespace lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digitalSignature = new DigitalSignature();

            //digitalSignature.AssignNewKey("./publicKey.xml");
            //digitalSignature.DeleteKeyInCsp();

            string data = "data";
            string data2 = "Data";

            var signature = digitalSignature.SignData(Convert.FromBase64String(data));
            var signature2 = digitalSignature.SignData(Convert.FromBase64String(data2));

            if (DigitalSignature.VerifySignature("./publicKey.xml", Convert.FromBase64String(data), signature))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            Console.WriteLine();
            
            if (DigitalSignature.VerifySignature("./publicKey.xml", Convert.FromBase64String(data2), signature))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}