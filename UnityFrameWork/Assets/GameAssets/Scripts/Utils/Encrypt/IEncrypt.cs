using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core.Utils
{
    public interface IEncrypt_Decrypt
    {
        void EncryptBundle(string bundlePath);

        void DecryptBundle(string bundlePath);
    }
}

