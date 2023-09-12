using System;
using System.Security.Cryptography;
using System.Text;
namespace Lab._2._3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] encryptedMessage = File.ReadAllBytes("D:/Навчання/інформаційна безпека лаби/Lab2/lab2.3/encfile.dat");
            int lenght = encryptedMessage.Length;
            string data = Encoding.UTF8.GetString(encryptedMessage);
            //Console.WriteLine(data);
            int i1 = data.IndexOf("Mit21");
            FindKey(data);
        }
        static void FindKey(string data)
        {
            string sumbols = "opasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            int i1;
            string key = "";
            string decData;
            foreach (char c1 in "yuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM")
            {
                key += c1;
                foreach (char c2 in sumbols)
                {
                    key += c2;
                    foreach (char c3 in sumbols)
                    {
                        key += c3;
                        foreach (char c4 in sumbols)
                        {
                            key += c4;
                            foreach (char c5 in sumbols)
                            {
                                key += c5;
                                decData = Coding(data, key);
                                i1 = decData.IndexOf("Mit21");
                                if (i1 != -1)
                                {
                                    Console.Write("key: ");
                                    Console.WriteLine(key);
                                    Console.Write("Message: ");
                                    Console.WriteLine(decData);
                                    Console.ReadLine();
                                    //SaveData(key, "D:\\Навчання\\інформаційна безпека лаби\\Lab2\\lab2.3\\answers.txt");
                                    //SaveData(data, "D:\\Навчання\\інформаційна безпека лаби\\Lab2\\lab2.3\\answers.txt");
                                    //return;
                                }
                                //Console.WriteLine(key);
                                key = key.Remove(4);
                            }
                            key = key.Remove(3);
                        }
                        key = key.Remove(2);
                    }
                    key = key.Remove(1);
                }
                key = key.Remove(0);
            }
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
        static void SaveData(string path, string data) 
        {
            using (StreamWriter writer = new StreamWriter(path)) 
            { 
                writer.Write(data);
            }
        }
    }
}