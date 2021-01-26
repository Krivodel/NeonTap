using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class Settings
    {
        public static Settings Instance => _instance ?? (_instance = new Settings());
        private static Settings _instance;

        private readonly SettingsData Data;

        private Settings()
        {
            Data = SettingsData.Instance;

            if (PlayerPrefs.HasKey(Data.AdPeriodicStepKey))
                SetAdPeriodicStep(PlayerPrefs.GetInt(Data.AdPeriodicStepKey));

            if (PlayerPrefs.HasKey(Data.SoundKey))
                SetSound(PlayerPrefs.GetFloat(Data.SoundKey));
            else
                SetSound(Data.Sound);

            if (PlayerPrefs.HasKey(Data.MusicKey))
                SetMusic(PlayerPrefs.GetInt(Data.MusicKey) != 0);
            else
                SetMusic(Data.Music);

            if (PlayerPrefs.HasKey(Data.CounterStepKey))
                SetCounterStep(PlayerPrefs.GetInt(Data.CounterStepKey));
            else
                SetCounterStep(Data.CounterStep);

            if (PlayerPrefs.HasKey(Data.LearningKey))
                SetPowerUpStudy(PlayerPrefs.GetString(Data.LearningKey));

            EventBus.Instance.Register<ApplicationQuitEvent>(OnApplicationQuit);
        }

        private void OnApplicationQuit(ApplicationQuitEvent data)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(Data.AdPeriodicStepKey, Data.AdPeriodicStep);
            PlayerPrefs.SetFloat(Data.SoundKey, Data.Sound);
            PlayerPrefs.SetInt(Data.MusicKey, Data.Music ? 1 : 0);
            PlayerPrefs.SetInt(Data.CounterStepKey, Data.CounterStep);
            PlayerPrefs.SetString(Data.LearningKey, Data.Learning.GetString());
        }

        public void SetAdPeriodicStep(int step)
        {
            Data.AdPeriodicStep = step;
        }

        public int GetAdPeriodicStep()
        {
            return Data.AdPeriodicStep;
        }

        public void SetFPS(int value)
        {
            Application.targetFrameRate = value;
        }

        public float GetSound()
        {
            return Data.Sound;
        }

        public void SetSound(float value)
        {
            value = Mathf.Clamp01(value);

            Data.Sound = value;
            AudioListener.volume = value;
        }

        public bool GetMusic()
        {
            return Data.Music;
        }

        public void SetMusic(bool value)
        {
            Data.Music = value;

            EventBus.Instance.PostEvent(new SettingsMusicChangedEvent(value));
        }

        public int GetCounterStep()
        {
            return Data.CounterStep;
        }

        public void SetCounterStep(int value)
        {
            Data.CounterStep = value;

            EventBus.Instance.PostEvent(new SettingsCounterStepChangedEvent(value));
        }

        public void SetPowerUpStudy(string newPowerUpStudy)
        {
            Data.Learning.SetFromString(newPowerUpStudy);
        }
    }
}
