using UnityEngine;

namespace Krivodeling.RateAppSystem
{
    [CreateAssetMenu(fileName = "RateAppData", menuName = "Krivodeling/Rate App/ Rate App Data")]
    public class RateAppData : ScriptableObject
    {
        public static RateAppData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Resources.Load<RateAppData>("RateAppData");

                return _instance;
            }
        }
        private static RateAppData _instance;

        [HideInInspector] public string PackageName;

#if UNITY_EDITOR
        private void OnEnable()
        {
            PackageName = UnityEditor.PlayerSettings.applicationIdentifier;

            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }
}
