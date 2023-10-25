using lab5._2;
using System.Security.Cryptography;
using System.Text;

namespace Lab5._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, byte[][]> pairs = new Dictionary<string, byte[][]>();
            HashAlgorithmName algorithm = PBKDF2.SetHashAlgorithm("SHA512");
            AddUser(pairs, algorithm);
            AddUser(pairs, algorithm);
            AddUser(pairs, algorithm);
            PrintPairs(pairs);
        }

        private static byte[] HashPassword(string passwordToHash, byte[] salt, int numberOfRounds, HashAlgorithmName hashAlgorithm)
        {
            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(passwordToHash), salt, numberOfRounds, hashAlgorithm);
            return hashedPassword;
        }

        static void AddUser(Dictionary<string, byte[][]> pairs, HashAlgorithmName hashAlgorithm)
        {
            int numberOfRounds = 20 * 10000;
            string password;
            byte[] hashedPassword, salt;
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();

            if (pairs.ContainsKey(login))
            {
                Console.WriteLine("Authorization.....");
                Console.WriteLine("Enter pwd: ");
                password = Console.ReadLine();
                hashedPassword = HashPassword(password, pairs[login][0],numberOfRounds, hashAlgorithm);
                if (Enumerable.SequenceEqual(hashedPassword, pairs[login][1]))
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
                password = Console.ReadLine();
                salt = PBKDF2.GenerateSalt();
                hashedPassword = HashPassword(password, salt, numberOfRounds, hashAlgorithm);
                byte[][] value = new byte[2][];
                value[0] = salt; value[1] = hashedPassword;
                pairs.Add(login, value);
                Console.WriteLine("Added");
            }
        }
        static void PrintPairs(Dictionary<string, byte[][]> pairs)
        {
            foreach (var pair in pairs)
            {
                Console.WriteLine($"key: {pair.Key}  salt: {Convert.ToBase64String(pair.Value[0])} hashed pwd: {Convert.ToBase64String(pair.Value[1])}");
            }
        }
    }
}