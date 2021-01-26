using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "New Trap Sound", menuName = EditorConfig.MAIN_MENU + "Trap Sound")]
    public class TrapSoundData : ScriptableObject
    {
        [HideInInspector] public AudioSource AudioSource;
        public AudioClip TakenSound;

        public void Init()
        {
            AudioSource = new GameObject("[TrapSound - AudioSource]").AddComponent<AudioSource>();

            AudioSource.gameObject.hideFlags = HideFlags.HideAndDontSave;
            AudioSource.volume = 0.64f;
            AudioSource.playOnAwake = false;
        }
    }
}
