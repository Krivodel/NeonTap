using UnityEngine;
using UnityEditor;
using static Krivodeling.Animation.TransformAnimatorPresets;

namespace Krivodeling.Animation.Editor
{
    public class TransformAnimatorPresetsWindow : EditorWindow
    {
        #region Variables
        private static TransformAnimatorPresetsWindow Window;

        private TransformAnimator animator;

        private Vector2 scrollPosition;
        private TransformAnimatorPreset[] presets;
        private string[] names;

        private string inputNewPresetName = string.Empty;
        private string newPresetName = string.Empty;
        #endregion

        #region Methods
        [MenuItem("Krivodeling/Animation/Transform Animator/Presets")]
        public static void Open()
        {
            Open(null);
        }

        public static void Open(TransformAnimator animator)
        {
            Window = GetWindow<TransformAnimatorPresetsWindow>("Transform Animator Presets");

            Window.Show();

            if (animator != null)
                Window.animator = animator;
        }

        private void OnEnable()
        {
            UpdateAll();
        }

        private void OnDisable()
        {
            Window = null;
        }

        private void OnGUI()
        {
            Color guiColor = GUI.color;

            if (presets.Length > 0)
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, EditorStyles.helpBox);
                {
                    for (int i = 0; i < presets.Length; i++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        {
                            names[i] = GUILayout.TextField(names[i]);
                            
                            GUI.color = Color.cyan;

                            if (animator != null)
                                if (GUILayout.Button("Set To Animator", GUILayout.Width(105f)))
                                    animator.LoadPreset(GetPresetByIndex(i));

                            GUI.color = Color.magenta;

                            if (GUILayout.Button("Rename", GUILayout.Width(60f)))
                            {
                                RenamePreset(i, names[i]);
                                UpdateNames();
                            }

                            GUI.color = Color.yellow;

                            if (GUILayout.Button("Select", GUILayout.Width(50f)))
                                SelectPreset(i);

                            GUI.color = Color.red;

                            if (GUILayout.Button("X", GUILayout.Width(20f)))
                            {
                                if (EditorUtility.DisplayDialog("Delete preset", "Delete [" + names[i] + "] preset?", "Delete", DialogOptOutDecisionType.ForThisSession, "Cancel"))
                                {
                                    DeletePreset(i);
                                    UpdateAll();
                                }
                            }

                            GUI.color = guiColor;
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                EditorGUILayout.EndScrollView();
            }
            else
                EditorGUILayout.LabelField("Empty", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            {
                inputNewPresetName = GUILayout.TextField(inputNewPresetName);
                newPresetName = inputNewPresetName.Trim();

                if (newPresetName != string.Empty)
                {
                    if (GUILayout.Button("Create Preset", EditorStyles.miniButtonRight))
                    {
                        CreatePreset(animator.Animation, newPresetName);
                        UpdateAll();
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private void UpdateAll()
        {
            UpdatePresets();
            UpdateNames();
        }

        private void UpdatePresets()
        {
            presets = GetAllPresets(true);
        }

        private void UpdateNames()
        {
            names = GetPresetsNames();
        }
        #endregion
    }
}
