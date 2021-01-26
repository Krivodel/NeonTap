using UnityEngine;

using Project.EventBusSystem;

namespace Project.Monetization
{
    public class AdPeriodic
    {
        private pint interval = 6;
        private pint step = 1;

        private AdPeriodic()
        {
            step = Settings.Instance.GetAdPeriodicStep();

            EventBus e = EventBus.Instance;

            e.Register<StopGameEvent>(OnStopGame);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            new AdPeriodic();
        }

        private void OnStopGame(StopGameEvent data)
        {
            step++;

            if (step % interval == 0 || step > interval)
            {
                step = 0;

                AdManager.Instance.ShowInterstitialAd();
            }

            Settings.Instance.SetAdPeriodicStep(step);
        }
    }
}
