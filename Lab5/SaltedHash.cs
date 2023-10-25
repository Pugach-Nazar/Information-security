using System.Security.Cryptography;

namespace Lab5._1
{
    internal class SaltedHashs
    {
        public byte[] GenerateSalt()
        {
            const int saltLength = 32;
            var randomNumberGenerator = new RNGCryptoServiceProvider();
            var randomNumber = new byte[saltLength];
            randomNumberGenerator.GetBytes(randomNumber);
            return randomNumber;
        }


        private byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        public byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            var sha256 = SHA256.Create();

            return sha256.ComputeHash(Combine(toBeHashed, salt));

        }
    }

}
