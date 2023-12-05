using System.Security.Cryptography;

namespace lab9
{
    internal class DigitalSignature
    {
        const string ContainerName = "MyContainer";
        public void AssignNewKey(string publicKeyPath)
        {
            var cspParams = new CspParameters(1)
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore,
                ProviderName = "Microsoft Strong Cryptographic Provider"
            };
            var rsa = new RSACryptoServiceProvider(2048, cspParams)
            {
                PersistKeyInCsp = true
            };
            File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
        }
        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName
            };
            var rsa = new RSACryptoServiceProvider(cspParams)
            {
                PersistKeyInCsp = false
            };
            rsa.Clear();
        }
        public byte[] SignData(byte[] dataToSign)
        {
            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                rsa.PersistKeyInCsp = true;

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm(nameof(SHA512));

                using (var sha512 = SHA512.Create())
                {
                    byte[] hashOfData = sha512.ComputeHash(dataToSign);
                    return rsaFormatter.CreateSignature(hashOfData);
                }
            }
        }
        public static bool VerifySignature(string publicKeyPath, byte[] data, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm(nameof(SHA512));

                using (var sha512 = SHA512.Create())
                {
                    byte[] hashOfData = sha512.ComputeHash(data);
                    return rsaDeformatter.VerifySignature(hashOfData, signature);
                }
            }
        }
    }
}
