using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class PlayerSkinInfo
    {
        public static PlayerSkinInfo Instance => _instance ?? (_instance = new PlayerSkinInfo());
        private static PlayerSkinInfo _instance;

        public const string LAST_SKIN_KEY = "LastPlayerSkin";

        public PlayerSkinData[] Data { get; private set; }
        public PlayerSkinData LastSkin { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Awake()
        {
            Instance.Data = Resources.LoadAll<PlayerSkinData>(PathConfig.PLAYER_SKINS);

            if (PlayerPrefs.HasKey(LAST_SKIN_KEY))
            {
                int index = PlayerPrefs.GetInt(LAST_SKIN_KEY);

                Instance.LastSkin = Instance.Data[index];
            }
            else
            {
                Instance.LastSkin = Instance.Data[0];
            }

            EventBus.Instance.RegisterListenerEvent(typeof(PlayerSkinChangeEvent), new EventListener<PlayerSkinChangeEvent>(Instance.OnPlayerSkinChange));
        }

        private void OnPlayerSkinChange(PlayerSkinChangeEvent data)
        {
            LastSkin = data.Data;

            PlayerPrefs.SetInt(LAST_SKIN_KEY, GetSkinIndex(LastSkin));
        }

        private int GetSkinIndex(PlayerSkinData data)
        {
            for (int i = 0; i < Data.Length; i++)
                if (Data[i] == data)
                    return i;

            return 0;
        }
    }
}
