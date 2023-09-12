using System;
using System.Text;

namespace Lab._2._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input data");
            string data = Console.ReadLine();
            Console.WriteLine(data);


            string key = "key";
            string decdata = Coding(data, key);
            Console.WriteLine(Coding(data, key));
            Console.WriteLine(Coding(decdata, key));
        }
        static string Coding(string data, string key)
        {

            byte[] Bkey = Encoding.UTF8.GetBytes(key);
            byte[] bData = Encoding.UTF8.GetBytes(data);
            byte[] encryptedMessage = new byte[bData.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedMessage[i] = (byte)(bData[i] ^ Bkey[i % Bkey.Length]);
            }
            return Encoding.UTF8.GetString(encryptedMessage);
        }
    }
}