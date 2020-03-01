using System;
using System.Security.Cryptography;
using System.Text;

namespace Scanner.API.Common.Securities {
    public static class AsymmetricEncryption {
        private const int KeySize = 1024;
        private const bool OptimalAsymmetricEncryptionPadding = false;

        public static void GenerateKeys(int keySize, out string publicKey, out string publicAndPrivateKey) {
            using (var provider = new RSACryptoServiceProvider(keySize)) {
                publicKey = provider.ToXmlString(false);
                publicAndPrivateKey = provider.ToXmlString(true);
            }
        }

        public static string EncryptText(string text, string publicKeyXml, int keySize = KeySize) {
            var encrypted = Encrypt(Encoding.UTF8.GetBytes(text), keySize, publicKeyXml);
            return Convert.ToBase64String(encrypted);
        }

        private static byte[] Encrypt(byte[] data, int keySize, string publicKeyXml) {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data are empty", "data");
            int maxLength = GetMaxDataLength(keySize);
            if (data.Length > maxLength)
                throw new ArgumentException(string.Format("Maximum data length is {0}", maxLength), "data");
            if (!IsKeySizeValid(keySize))
                throw new ArgumentException("Key size is not valid", "keySize");
            if (string.IsNullOrEmpty(publicKeyXml))
                throw new ArgumentException("Key is null or empty", "publicKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize)) {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, OptimalAsymmetricEncryptionPadding);
            }
        }

        public static string DecryptText(string text, string publicAndPrivateKeyXml, int keySize = KeySize) {
            var decrypted = Decrypt(Convert.FromBase64String(text), keySize, publicAndPrivateKeyXml);
            return Encoding.UTF8.GetString(decrypted);
        }

        private static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml) {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data are empty", "data");
            if (!IsKeySizeValid(keySize))
                throw new ArgumentException("Key size is not valid", "keySize");
            if (string.IsNullOrEmpty(publicAndPrivateKeyXml))
                throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize)) {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, OptimalAsymmetricEncryptionPadding);
            }
        }

        public static int GetMaxDataLength(int keySize) {
            if (OptimalAsymmetricEncryptionPadding) {
#pragma warning disable CS0162 // Unreachable code detected
                return ((keySize - 384) / 8) + 7;
#pragma warning restore CS0162 // Unreachable code detected
            }
            return ((keySize - 384) / 8) + 37;
        }

        public static bool IsKeySizeValid(int keySize) {
            return keySize >= 384 &&
                    keySize <= 16384 &&
                    keySize % 8 == 0;
        }
    }
}
