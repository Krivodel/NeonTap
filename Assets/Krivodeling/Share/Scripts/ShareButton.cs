using UnityEngine;
using UnityEngine.UI;

namespace Krivodeling.ShareSystem
{
    public class ShareButton : MonoBehaviour
    {
        [Tooltip("vk - Вконтакте\nok - Однолкассники\nfb - Facebook\ntw - Twitter\nwa - WhatsApp\nvb - Viber\ntg - Telegram")]
        public string App = "tw";

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (App != "ok")
                Sharing.Instance.ShareVia(App, ShareData.Instance.GetMessage());
            else
                Sharing.Instance.ShareVia(App, ShareData.Instance.GetMessage(), string.Format("{0};{1}", ShareData.Instance.OkAppId, ShareData.Instance.OkSecretId));
        }
    }
}
