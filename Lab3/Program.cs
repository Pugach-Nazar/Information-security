using System.Security.Cryptography;
using System.Text;

namespace lab3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data1 = "Hello World!";
            string data2 = "Hello world!";

            HashData(data1, ComputeHashMd5);
            Console.Write("Guid: ");
            Guid guid = new Guid(ComputeHashMd5(data1));
            Console.WriteLine(guid);
            Console.WriteLine();

            HashData(data2, ComputeHashMd5);
            Console.Write("Guid: ");
            guid = new Guid(ComputeHashMd5(data1));
            Console.WriteLine(guid);

            Console.WriteLine("--------------------------------------------");

            HashData(data1, ComputeHashSha1);
            HashData(data2, ComputeHashSha1);

            Console.WriteLine("--------------------------------------------");

            HashData(data1, ComputeHashSha256);
            HashData(data2, ComputeHashSha256);

            Console.WriteLine("--------------------------------------------");

            HashData(data1, ComputeHashSha384);
            HashData(data2, ComputeHashSha384);

            Console.WriteLine("--------------------------------------------");

            HashData(data1, ComputeHashSha512);
            HashData(data2, ComputeHashSha512);

            Console.WriteLine("--------------------------------------------");

        }
        static byte[] ComputeHashMd5(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(bData);
            }
        }
        static byte[] ComputeHashSha1(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(bData);
            }
        }
        static byte[] ComputeHashSha256(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(bData);
            }
        }
        static byte[] ComputeHashSha384(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(bData);
            }
        }
        static byte[] ComputeHashSha512(string data)
        {
            byte[] bData = Encoding.UTF8.GetBytes(data);
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(bData);
            }
        }
        static void HashData(string data, Func<string, byte[]> hashfunc)
        {
            var hash = hashfunc(data);

            Console.WriteLine(data);
            Console.Write("Hash: ");
            Console.WriteLine(Convert.ToBase64String(hash));
            Console.WriteLine();

        }
    }
}
