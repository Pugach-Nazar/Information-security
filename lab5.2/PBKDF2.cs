using System.Security.Cryptography;

namespace lab5._2
{
    internal class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds, HashAlgorithmName hashAlgorithm)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, hashAlgorithm))
            {
                return rfc2898.GetBytes(32);
            }
        }

    }

    //private Func<byte[], byte[]> hashFunc = ComputeHashMd5;

    //public static byte[] GenerateSalt()
    //{
    //    const int saltLength = 32;
    //    var randomNumberGenerator = new RNGCryptoServiceProvider();
    //    var randomNumber = new byte[saltLength];
    //    randomNumberGenerator.GetBytes(randomNumber);
    //    return randomNumber;
    //}
    //private static byte[] ComputeHashMd5(byte[] data)
    //{
    //    using (var md5 = MD5.Create())
    //    {
    //        return md5.ComputeHash(data);
    //    }
    //}

    //private static byte[] ComputeHashSha1(byte[] data)
    //{
    //    using (var sha1 = SHA1.Create())
    //    {
    //        return sha1.ComputeHash(data);
    //    }
    //}

    //private static byte[] ComputeHashSha256(byte[] data)
    //{
    //    using (var sha256 = SHA256.Create())
    //    {
    //        return sha256.ComputeHash(data);
    //    }
    //}

    //private static byte[] ComputeHashSha384(byte[] data)
    //{
    //    using (var sha384 = SHA384.Create())
    //    {
    //        return sha384.ComputeHash(data);
    //    }
    //}

    //private static byte[] ComputeHashSha512(byte[] data)
    //{
    //    using (var sha512 = SHA512.Create())
    //    {
    //        return sha512.ComputeHash(data);
    //    }
    //}

    //public void HashData(string data, Func<string, byte[]> hashfunc)
    //{
    //    var hash = hashfunc(data);

    //    Console.WriteLine(data);
    //    Console.Write("Hash: ");
    //    Console.WriteLine(Convert.ToBase64String(hash));
    //    Console.WriteLine();
    //}

    //private static byte[] Combine(byte[] first, byte[] second)
    //{
    //    var ret = new byte[first.Length + second.Length];
    //    Buffer.BlockCopy(first, 0, ret, 0, first.Length);
    //    Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
    //    return ret;
    //}
    //public byte[] HashPasswordWithSalt(byte[] toBeHashed)
    //{
    //    return hashFunc(Combine(toBeHashed, salt));

    //}

    //public byte[] HashPasswordWithSalt(byte[] toBeHashed, int iterations)
    //{
    //    byte[] ret = HashPasswordWithSalt(toBeHashed);
    //    for (int i = 0; i < (iterations-1); i++)
    //    {
    //         ret = HashPasswordWithSalt(ret);
    //    }
    //    return ret;
    //}
    //public void SetHashFunc(string type) 
    //{
    //    switch (type)
    //    {
    //        case "Md5":
    //            hashFunc = ComputeHashMd5;
    //            break;
    //        case "Sha1":
    //            hashFunc = ComputeHashSha1;
    //            break;
    //        case "Sha256":
    //            hashFunc = ComputeHashSha256;
    //            break;
    //        case "Sha384":
    //            hashFunc = ComputeHashSha384;
    //            break;
    //        case "Sha512":
    //            hashFunc = ComputeHashSha512;
    //            break;
    //        default: hashFunc = ComputeHashMd5;
    //            break;
    //    }

    //}
    //public byte[] HashPassword(byte[] toBeHashed, int numberOfRounds)
    //{
    //    using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
    //    {
    //        return rfc2898.GetBytes(20);
    //    }
    //}
}
