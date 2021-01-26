using System;
using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project.Monetization
{
    public class RewardedAdButton : MonoBehaviour
    {
        private Button _button;

        public GameObject Badge;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            AdManager.Instance.onRewardedAdLoaded += Active;
            AdManager.Instance.onRewardedAdOpening += Disactive;

            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            AdManager.Instance.ShowRewardedAd();

#if UNITY_EDITOR
            EventBus.Instance.PostEvent(new PlayerHealthRecoveredEvent(1));
            EventBus.Instance.PostEvent(new RewardedAdViewedEvent());
#endif
        }

        private void Active(object sender, EventArgs args)
        {
            _button.interactable = true;
            Badge.SetActive(true);
        }

        private void Disactive(object sender, EventArgs args)
        {
            _button.interactable = false;
            Badge.SetActive(false);
        }
    }
}
