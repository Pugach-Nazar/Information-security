using System.Security.Cryptography;
using System.Text;

namespace lab3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string needHash = "po1MVkAE7IjUUwu61XxgNg==";
            FindKey(needHash);
        }

        static void FindKey(string hash)
        {
            string probablyData = "", sHash;
            string symbols = "1234567890";
            byte[] bHash, md5Hash = Convert.FromBase64String(hash);
            Guid guid;

            foreach (char c1 in symbols)
            {
                foreach (char c2 in symbols)
                {
                    foreach (char c3 in symbols)
                    {
                        foreach (char c4 in symbols)
                        {
                            foreach (char c5 in symbols)
                            {
                                foreach (char c6 in symbols)
                                {
                                    foreach (char c7 in symbols)
                                    {
                                        foreach (char c8 in symbols)
                                        {
                                            probablyData = "";
                                            probablyData += c1;
                                            probablyData += c2;
                                            probablyData += c3;
                                            probablyData += c4;
                                            probablyData += c5;
                                            probablyData += c6;
                                            probablyData += c7;
                                            probablyData += c8;
                                            bHash = ComputeHashMd5(probablyData);

                                            if (Enumerable.SequenceEqual(bHash, md5Hash))
                                            {
                                                sHash = Convert.ToBase64String(bHash);
                                                Console.WriteLine(probablyData);
                                                Console.WriteLine($"hash: {sHash}");
                                                guid = new Guid(bHash);
                                                Console.WriteLine($"Guid: {guid}");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static byte[] ComputeHashMd5(string data)
        {
            byte[] bData = Encoding.Unicode.GetBytes(data);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(bData);
            }
        }

        //static void FindKey(string needHash)
        //{
        //    byte[] md5Hash = Convert.FromBase64String(needHash);
        //    string key;
        //    for (int i = 0; i <= 100000000; i += 1)
        //    {
        //        key = Convert.ToString(i).PadLeft(8, '0');

        //        if (Enumerable.SequenceEqual(ComputeHashMd5(key), md5Hash))
        //        {
        //            Console.WriteLine(key);
        //            break;
        //        }

        //    }
        //}
    }
}