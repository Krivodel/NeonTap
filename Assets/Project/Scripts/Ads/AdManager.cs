using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;

namespace Project.Monetization
{
    public class AdManager : MonoBehaviour
    {
        #region Variables
        public static AdManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("[AdManager]").AddComponent<AdManager>();

                    _instance.gameObject.hideFlags = HideFlags.HideAndDontSave;

                    _instance.Initialize();
                }

                return _instance;
            }
        }
        private static AdManager _instance;

        private AdRequest interstitialAdRequest;
        private InterstitialAd interstitialAd;
        private AdRequest rewardedAdRequest;
        private RewardedAd rewardedAd;

        private WaitForSeconds waitInterstitial, waitRewarded;

#if TEST_ADMOB
        private const string INTERSTITIAL_ID = "ca-app-pub-3940256099942544/1033173712"; // test
        private const string MENU_REWARD_ID = "ca-app-pub-3940256099942544/5224354917"; // test
#else
        private const string INTERSTITIAL_ID = "ca-app-pub-5860310810917736/5077686843";
        private const string MENU_REWARD_ID = "ca-app-pub-5860310810917736/6149943980";
#endif
        #endregion

        #region Events
        public delegate void InterstitialAdLoaded(object sender, EventArgs args);
        public InterstitialAdLoaded onInterstitialAdLoaded;
        private void OnInterstitialAdLoaded(object sender, EventArgs args) => onInterstitialAdLoaded?.Invoke(sender, args);

        public delegate void RewardedAdLoaded(object sender, EventArgs args);
        public event RewardedAdLoaded onRewardedAdLoaded;
        private void OnRewardedAdLoaded(object sender, EventArgs args) => onRewardedAdLoaded?.Invoke(sender, args);

        public delegate void RewardedAdOpening(object sender, EventArgs args);
        public event RewardedAdOpening onRewardedAdOpening;
        private void OnRewardedAdOpening(object sender, EventArgs args) => onRewardedAdOpening?.Invoke(sender, args);

        public delegate void UserEarnedReward(object sender, Reward args);
        public event UserEarnedReward onUserEarnedReward;
        private void OnUserEarnedReward(object sender, Reward args) => onUserEarnedReward?.Invoke(sender, args);
        #endregion

        #region Methods
        private void Initialize()
        {
            MobileAds.Initialize(initStatus => { });

            LoadInterstitialAd();
            LoadRewardedAd();

            waitInterstitial = new WaitForSeconds(60f);
            waitRewarded = new WaitForSeconds(60f);

            StartCoroutine(CheckLoadInterstitialAdCoroutine());
            StartCoroutine(CheckLoadRewardedAdCoroutine());
        }

        private void LoadInterstitialAd()
        {
            interstitialAd = new InterstitialAd(INTERSTITIAL_ID);

            interstitialAdRequest = new AdRequest.Builder().Build();

            interstitialAd.OnAdLoaded += OnInterstitialAdLoaded;
            interstitialAd.OnAdClosed += delegate { LoadInterstitialAd(); };

            interstitialAd.LoadAd(interstitialAdRequest);
        }

        public bool InterstitialIsLoaded() => interstitialAd.IsLoaded();

        private IEnumerator CheckLoadInterstitialAdCoroutine()
        {
            yield return waitInterstitial;

            if (!interstitialAd.IsLoaded())
                LoadInterstitialAd();

            StartCoroutine(CheckLoadInterstitialAdCoroutine());
        }

        private void LoadRewardedAd()
        {
            rewardedAd = new RewardedAd(MENU_REWARD_ID);

            rewardedAdRequest = new AdRequest.Builder().Build();

            rewardedAd.OnAdLoaded += OnRewardedAdLoaded;
            rewardedAd.OnAdClosed += delegate { LoadRewardedAd(); };
            rewardedAd.OnAdOpening += OnRewardedAdOpening;
            rewardedAd.OnUserEarnedReward += OnUserEarnedReward;

            rewardedAd.LoadAd(rewardedAdRequest);
        }

        public bool RewardedIsLoaded() => rewardedAd.IsLoaded();

        private IEnumerator CheckLoadRewardedAdCoroutine()
        {
            yield return waitRewarded;

            if (!rewardedAd.IsLoaded())
                LoadRewardedAd();

            StartCoroutine(CheckLoadRewardedAdCoroutine());
        }

        public void ShowInterstitialAd()
        {
            if (InterstitialIsLoaded())
                interstitialAd.Show();
            else
                LoadInterstitialAd();
        }

        public void ShowRewardedAd()
        {
            if (RewardedIsLoaded())
                rewardedAd.Show();
            else
                LoadRewardedAd();
        }
        #endregion
    }
}
