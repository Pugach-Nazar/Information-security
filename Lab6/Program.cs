using lab5._2;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Des Example:\n");
            DesEncryption.DesExample();

            Console.WriteLine("Triple Des Example:\n");
            TripleDesEncryption.TripleDesExample();

            Console.WriteLine("Aes Example:\n");
            AesEncryption.AesExample();

            Console.WriteLine("2-nd Task");
            var aes = new AesEncryption();

            var key = aes.GenerateRandomNumber(32);
            Console.Write("Random key: ");
            Console.WriteLine(Convert.ToBase64String(key) + "\n");

            key = PBKDF2.HashPassword(key, PBKDF2.GenerateSalt(), 20 * 10000, key.Length);
            Console.Write("Key after hashfunc: ");
            Console.WriteLine(Convert.ToBase64String(key));

            var iv = aes.GenerateRandomNumber(16);
            Console.Write("Random iv: ");
            Console.WriteLine(Convert.ToBase64String(iv) + "\n");
            iv = PBKDF2.HashPassword(iv, PBKDF2.GenerateSalt(), 20 * 10000, iv.Length);
            Console.Write("Iv after hashfunc: ");
            Console.WriteLine(Convert.ToBase64String(iv));

            Console.Write("Input key:");
            string original = Console.ReadLine();
            var encrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = aes.Decrypt(encrypted, key, iv);
            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
        }
    }
    
}