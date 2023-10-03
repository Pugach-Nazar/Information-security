using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, byte[]> pairs = new Dictionary<string, byte[]>();
            AddUser(pairs);
            AddUser(pairs);
            AddUser(pairs);
            PrintPairs(pairs);
        }
        static byte[] ComputeHashMd5(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(bData);
            }
        }
        static void AddUser(Dictionary<string, byte[]> pairs)
        {
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();

            string pwd;
            byte[] pwdHass;
            if (pairs.ContainsKey(login))
            {
                Console.WriteLine("Authorization.....");
                Console.WriteLine("Enter pwd: ");
                pwd = Console.ReadLine();
                pwdHass = ComputeHashMd5(pwd);
                if (Enumerable.SequenceEqual(pwdHass, pairs[login]))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("Enter pwd: ");
                pwd = Console.ReadLine();
                pwdHass = ComputeHashMd5(pwd);
                pairs.Add(login, pwdHass);
                Console.WriteLine("Added");
            }
        }
        static void PrintPairs(Dictionary<string, byte[]> pairs)
        {
            foreach(var pair in pairs)
            {
                Console.WriteLine($"key: {pair.Key}  value: {Convert.ToBase64String(pair.Value)}");
            }
        }
    }
}

