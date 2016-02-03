using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.EncryptionSettings.Service
{
    public interface IEncryptionSettingsService
    {
        string EncryptValue(string value);
        string DecryptValue(string encryptedText);
        void SetEncryptionKey(string newKey);
        bool RequiresSetup();
    }
}
