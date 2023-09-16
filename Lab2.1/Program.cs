using System;
using System.Text;
using System.IO;

namespace Lab._2._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Input data");
            //string data = Console.ReadLine();
            //Console.WriteLine(data);
            //string key = "key";
            //string decdata = Cryption(data, key);
            //Console.WriteLine(Cryption(data, key));
            //Console.WriteLine(Cryption(decdata, key));
            string encData,key, data = ReadDataFromFile("./data.txt");
            Console.WriteLine(data);

            //Console.Write("Input key:");
            //key = Console.ReadLine();

            key = "123";

            encData = Cryption(data,key);

            WriteDataInFile(encData, "./encData.dat");
            Console.WriteLine(ReadDataFromFile("./encData.dat"));
            Console.WriteLine(Cryption(ReadDataFromFile("./encData.dat"),key));
        }

        static string ReadDataFromFile(string path) 
        {
            byte[] data = File.ReadAllBytes(path);
            return Encoding.UTF8.GetString(data);
        }
        static void WriteDataInFile(string data, string path)
        {
            using (StreamWriter writer = new StreamWriter(path)) 
            {
                writer.WriteLine(data);
            }
        }
        
        static string Cryption(string data, string key = "key")
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