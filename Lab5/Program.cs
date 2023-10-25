using System;
using System.Security.Cryptography;
using System.Text;

namespace Lab5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaltedHashs saltedHashs = new SaltedHashs();
            
            byte[] salt = saltedHashs.GenerateSalt();
            string pwd = "pwd";

            Console.WriteLine("Enter pwd");
            pwd = Console.ReadLine();

            byte[] bytePwd = Encoding.UTF8.GetBytes(pwd);
            byte[] hashPwdWithSalt = saltedHashs.HashPasswordWithSalt(salt, bytePwd);
            Console.WriteLine(Convert.ToBase64String(hashPwdWithSalt));
        }
    }
}