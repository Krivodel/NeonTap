using UnityEngine;

namespace Project
{
    public enum Complexity
    {
        Easy = 0,
        Normal = 1,
        Heavy = 2
    }

    [CreateAssetMenu(fileName = "New Profile", menuName = EditorConfig.MAIN_MENU + "Profile")]
    public class Profile : ScriptableObject
    {
        public static Profile Instance => _instance ?? (_instance = Resources.Load<Profile>(PathConfig.PROFILE));
        private static Profile _instance;

        public Complexity Complexity;
        public pint Neons; // это на время
    }
}
