using UnityEngine;
using System.Text;

namespace Project.Security
{
    internal class Encryption : MonoBehaviour
    {
        #region Variables
        internal static Encryption Instance;

        public pstring key = "இఆŶa¤ጝo㌵▶ㅇ䘺兑巛ᓅይ༸";
        #endregion

        #region Methods
        private void Awake()
        {
            Instance = this;
        }

        internal string Encrypt(string value)
        {
            string key = Instance.key + SystemInfo.deviceUniqueIdentifier;

            byte[] valueBytes = Encoding.Default.GetBytes(value);
            byte[] keyBytes = Encoding.Default.GetBytes(key);

            for (int i = 0, j = 0; i < valueBytes.Length; i++, j++)
            {
                valueBytes[i] ^= keyBytes[j];

                if (j == keyBytes.Length - 1)
                    j = 0;
            }

            return Encoding.Default.GetString(valueBytes);
        }

        internal string Decrypt(string value)
        {
            string key = Instance.key + SystemInfo.deviceUniqueIdentifier;

            byte[] valueBytes = Encoding.Default.GetBytes(value);
            byte[] keyBytes = Encoding.Default.GetBytes(key);

            for (int i = 0, j = 0; i < valueBytes.Length; i++, j++)
            {
                valueBytes[i] ^= keyBytes[j];

                if (j == keyBytes.Length - 1)
                    j = 0;
            }

            return Encoding.Default.GetString(valueBytes);
        }
        #endregion
    }
}
