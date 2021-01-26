using UnityEngine;
using GoogleMobileAds.Api;

using Project.EventBusSystem;

namespace Project.Monetization
{
    public class RewardedAdListener
    {
        private readonly string[] RewardedTypes = { "" };

        private RewardedAdListener()
        {
            AdManager.Instance.onUserEarnedReward += OnUserEarnedReward;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            new RewardedAdListener();
        }

        private void OnUserEarnedReward(object sender, Reward reward)
        {
#if TEST_ADMOB
            EventBus.Instance.PostEvent(new PlayerHealthRecoveredEvent(1));
#else
            EventBus.Instance.PostEvent(new PlayerHealthRecoveredEvent((pint)reward.Amount));
#endif

            EventBus.Instance.PostEvent(new RewardedAdViewedEvent());
        }
    }
}
