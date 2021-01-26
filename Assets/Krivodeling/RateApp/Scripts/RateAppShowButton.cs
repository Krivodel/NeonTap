using UnityEngine;
using UnityEngine.UI;

namespace Krivodeling.RateAppSystem
{
    public class RateAppShowButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            RateApp.Instance.Rate();
        }
    }
}
