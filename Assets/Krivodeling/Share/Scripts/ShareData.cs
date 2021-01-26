using UnityEngine;

namespace Krivodeling.ShareSystem
{
    [CreateAssetMenu(fileName = "ShareData", menuName = "Krivodeling/Share/Share Data")]
    public class ShareData : ScriptableObject
    {
        public static ShareData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<ShareData>("ShareData");

                    _instance.SetMessage(_instance.Message);
                }

                return _instance;
            }
        }
        private static ShareData _instance;

        public string OkAppId = "000";
        public string OkSecretId = "000";
        public string Url = "https://my.url.com";
        public string Message = "My Message!";

        private string _readyMessage;

        public string GetMessage()
        {
            return _readyMessage;
        }

        public void SetMessage(string formatMessage, params object[] args)
        {
            if (args.Length > 0)
                _readyMessage = string.Format(formatMessage, args);
            else
                _readyMessage = formatMessage;
        }
    }
}
