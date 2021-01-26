using UnityEngine;
using Doozy.Engine;

using Project.EventBusSystem;

namespace Project
{
    public class RewardedAdViewedSender : MonoBehaviour
    {
        public string GameEvent = "RewardedAdViewed";

        private void Awake()
        {
            EventBus.Instance.Register<RewardedAdViewedEvent>(OnRewardedAdViewed);
        }

        private void OnRewardedAdViewed(RewardedAdViewedEvent data)
        {
            Message.Send(new GameEventMessage(GameEvent));
        }
    }
}
