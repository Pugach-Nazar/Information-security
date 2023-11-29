using System;
using System.Security.Cryptography;
using System.Text;

namespace lab7._2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var asymmetricEncryption = new Task2Class();

            //string data = "We fight for rock and stone!";
            //byte[] byteData = Encoding.Unicode.GetBytes(data);
            //var encryptedData = asymmetricEncryption.EncryptData("C:\\Users\\Admin\\Desktop/Poliukhovych_publicKey.xml", byteData);
            //File.WriteAllBytes("C:\\Users\\Admin\\Desktop/Зашифровані дані.txt", encryptedData);

            var dataFromFile = File.ReadAllBytes("C:\\Users\\Admin\\Desktop/encryptedText.txt");
            var decryptedData = asymmetricEncryption.DecryptData("./privateKey.xml", dataFromFile);
            Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
        }
    }
}