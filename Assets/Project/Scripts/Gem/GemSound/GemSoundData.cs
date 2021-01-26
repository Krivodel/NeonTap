using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "New Gem Sound", menuName = EditorConfig.MAIN_MENU + "Gem Sound")]
    public class GemSoundData : ScriptableObject
    {
        [HideInInspector] public AudioSource AudioSource;
        public AudioClip TakenSound;
        public AudioClip DestroySound;

        public void Init()
        {
            AudioSource = new GameObject("[GemSound - AudioSource]").AddComponent<AudioSource>();

            AudioSource.gameObject.hideFlags = HideFlags.HideAndDontSave;
            AudioSource.volume = 0.64f;
            AudioSource.playOnAwake = false;
        }
    }
}
