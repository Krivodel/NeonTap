using UnityEngine;
using UnityEngine.UI;

namespace Krivodeling.ShareSystem
{
    public class ShareShowButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Sharing.Instance.Show();
        }
    }
}
