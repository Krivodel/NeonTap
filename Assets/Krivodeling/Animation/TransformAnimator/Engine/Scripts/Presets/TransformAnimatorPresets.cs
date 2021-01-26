using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Krivodeling.Animation
{
    public static class TransformAnimatorPresets
    {
        #region Variables
        private readonly static List<TransformAnimatorPreset> Presets = new List<TransformAnimatorPreset>();
        #endregion

        #region Events
        public delegate void Initialized();
        public static event Initialized onInitialized;
        private static void OnInitialized() => onInitialized?.Invoke();
        #endregion

        #region Methods
        [RuntimeInitializeOnLoadMethod]
        public static void Init()
        {
            TransformAnimatorPreset[] presets = Resources.LoadAll<TransformAnimatorPreset>("Presets");

            Presets.Clear();

            for (int i = 0; i < presets.Length; i++)
                Presets.Add(presets[i]);

            OnInitialized();
        }

        public static TransformAnimatorPreset[] GetAllPresets(bool init = false)
        {
            if (init)
                Init();

            return Presets.ToArray();
        }

        public static string[] GetPresetsNames(bool init = false)
        {
            if (init)
                Init();

            List<string> result = new List<string>();

            for (int i = 0; i < Presets.Count; i++)
                result.Add(Presets[i].name);

            return result.ToArray();
        }

        public static TransformAnimatorPreset GetPresetByName(string name, bool init = false)
        {
            if (init)
                Init();

            for (int i = 0; i < Presets.Count; i++)
                if (Presets[i].name == name)
                    return Presets[i];

            return null;
        }

        public static TransformAnimatorPreset GetPresetByIndex(int index, bool init = false)
        {
            if (init)
                Init();

            return Presets[index];
        }

        #endregion

        #region Editor
#if UNITY_EDITOR
        public static void CreatePreset(TransformAnimation animation, string name)
        {
            TransformAnimatorPreset preset = ScriptableObject.CreateInstance<TransformAnimatorPreset>();

            preset.name = name;
            preset.Animation = animation.Copy();

            string assetName = "Assets/Krivodeling/Animation/TransformAnimator/Engine/Resources/Presets/" + name + ".asset";
            assetName = AssetDatabase.GenerateUniqueAssetPath(assetName);

            AssetDatabase.CreateAsset(preset, assetName);

            AssetDatabase.SaveAssets();
        }

        public static void DeletePreset(int index)
        {
            AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(Presets[index]));

            AssetDatabase.SaveAssets();
        }

        public static void RenamePreset(int index, string newName)
        {
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(Presets[index]), newName);

            AssetDatabase.SaveAssets();
        }

        public static void SelectPreset(int index)
        {
            Selection.activeObject = Presets[index];
        }
#endif
        #endregion
    }
}
