using UnityEngine;

namespace Krivodeling.RateAppSystem
{
    public class RateApp
    {
        public static RateApp Instance => _instance ?? (_instance = new RateApp());
        private static RateApp _instance;

        public void Rate()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + RateAppData.Instance.PackageName);
#else
            Application.OpenURL("market://details?id=" + RateAppData.Instance.PackageName);
#endif
        }
    }
}
