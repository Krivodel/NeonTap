using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class MusicAudioSource : MonoBehaviour
    {
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();

            EventBus.Instance.Register<SettingsMusicChangedEvent>(OnSettingsMusicChanged);
        }

        private void OnSettingsMusicChanged(SettingsMusicChangedEvent data)
        {
            _source.enabled = data.Value;
        }
    }
}
