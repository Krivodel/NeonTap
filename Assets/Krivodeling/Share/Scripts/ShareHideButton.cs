using UnityEngine;
using UnityEngine.UI;

namespace Krivodeling.ShareSystem
{
    public class ShareHideButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Sharing.Instance.Hide();
        }
    }
}
