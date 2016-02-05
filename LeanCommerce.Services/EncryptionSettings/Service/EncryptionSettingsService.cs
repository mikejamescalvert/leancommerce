using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LeanCommerce.Services.EncryptionSettings.Service
{
    public class EncryptionSettingsService : IEncryptionSettingsService
    {
        private Model.EncryptionSettings settings;
        public EncryptionSettingsService()
        {
            LoadKey();
        }

        private static byte[] _salt = Encoding.ASCII.GetBytes("ac3o6806642kbM7c5");

        public string EncryptValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            if (string.IsNullOrEmpty(settings.EncryptionKey))
            {
                throw new ArgumentNullException("EncryptionKey");
            }
            return EncryptValue(value, settings.EncryptionKey);
        }
        private static string EncryptValue(string value, string sharedKey)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            if (string.IsNullOrEmpty(sharedKey))
            {
                throw new ArgumentNullException("EncryptionKey");
            }
            string outStr = null;
            RijndaelManaged aesAlg = null;

            try
            {
                var key = new Rfc2898DeriveBytes(sharedKey, _salt);


                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);


                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(value);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aesAlg != null)
                {
                    aesAlg.Clear();
                }
            }


            return outStr;
        }
        public string DecryptValue(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                throw new ArgumentNullException("encryptedText");
            }
            if (string.IsNullOrEmpty(settings.EncryptionKey))
            {
                throw new ArgumentNullException("EncryptionKey");
            }
            return DecryptValue(encryptedText, settings.EncryptionKey);
        }
        private static string DecryptValue(string encryptedText, string sharedKey)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                throw new ArgumentNullException("encryptedText");
            }
            if (string.IsNullOrEmpty(sharedKey))
            {
                throw new ArgumentNullException("EncryptionKey");
            }

            RijndaelManaged aesAlg = null;



            string plaintext = null;

            try
            {
                var key = new Rfc2898DeriveBytes(sharedKey, _salt);


                var bytes = Convert.FromBase64String(encryptedText);
                using (var msDecrypt = new MemoryStream(bytes))
                {
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                    aesAlg.IV = ReadByteArray(msDecrypt);

                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            finally
            {
                if (aesAlg != null)
                {
                    aesAlg.Clear();
                }
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            var rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        private void LoadKey()
        {

            string baseDirectory = (string)AppDomain.CurrentDomain.GetData("DataDirectory");
            if (string.IsNullOrEmpty(baseDirectory))
                baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var settingsPath = baseDirectory + "/encryption.config";
            if (System.IO.File.Exists(settingsPath) == true)
            {
                var data = System.IO.File.ReadAllText(settingsPath);
                settings = JsonConvert.DeserializeObject<Model.EncryptionSettings>(data);
            }
            if (settings == null)
            {
                settings = new Model.EncryptionSettings();
            }
        }
        private void SaveKey()
        {

            string baseDirectory = (string)AppDomain.CurrentDomain.GetData("DataDirectory");
            if (string.IsNullOrEmpty(baseDirectory))
                baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var settingsPath = baseDirectory + "/encryption.config";
            var data = JsonConvert.SerializeObject(settings);
            System.IO.File.WriteAllText(settingsPath, data);
        }
        public void SetEncryptionKey(string newKey)
        {
            if (settings == null)
            {
                settings = new Model.EncryptionSettings();
            }
            settings.EncryptionKey = newKey;
            SaveKey();
        }

        public bool RequiresSetup()
        {
            if (settings == null || string.IsNullOrEmpty(settings.EncryptionKey) == true)
            {
                return true;
            }
            return false;
        }
    }
}
