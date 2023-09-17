using System;
using System.Text;
using System.IO;

namespace Lab._2._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string decData,encData,key, data = ReadDataFromFile("./data.txt");
            Console.WriteLine(data);

            Console.Write("Input key:");
            key = Console.ReadLine();

            encData = Cryption(data,key);

            Console.WriteLine(ReadDataFromFile("./encData.dat"));
            WriteDataInFile(encData, "./encData.dat");
            decData = Cryption(ReadDataFromFile("./encData.dat"), key);
            Console.WriteLine(decData);
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