using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "New Settings", menuName = EditorConfig.MAIN_MENU + "Settings")]
    public class SettingsData : ScriptableObject
    {
        public static SettingsData Instance => _instance ?? (_instance = Resources.Load<SettingsData>(PathConfig.SETTINGS));
        private static SettingsData _instance;

        public string AdPeriodicStepKey = "AdPeriodicStep";
        public string SoundKey = "Sound";
        public string MusicKey = "Music";
        public string CounterStepKey = "CounterStep";
        public string LearningKey = "Learning";
        [Space]
        public int AdPeriodicStep = 1;
        public float Sound = 0.5f;
        public bool Music = true;
        public int CounterStep = 1;
        [Space]
        public LearningSettings Learning;
    }
}
