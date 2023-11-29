using System;
using System.Security.Cryptography;
using System.Text;
using lab7;

namespace lab7 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var asymmetricEncryption = new Lab7class();
            asymmetricEncryption.AssignNewKey();

            string data = "Data";

            var encrypted = asymmetricEncryption.EncryptData(Convert.FromBase64String(data));

            var decrypted = asymmetricEncryption.DecryptData(encrypted);

            Console.Write("Original text: ");
            Console.WriteLine(data);
            Console.WriteLine();
            Console.Write("Encrypted text: ");
            Console.WriteLine(Convert.ToBase64String(encrypted));
            Console.WriteLine();
            Console.Write("Decrypted text: ");
            Console.WriteLine(Convert.ToBase64String(decrypted));
        }
        
    }
}