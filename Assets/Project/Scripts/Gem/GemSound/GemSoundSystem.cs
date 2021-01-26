using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class GemSoundSystem : SystemBase
    {
        private GemSoundData Data;

        protected override void OnCreate()
        {
            Data = Resources.Load<GemSoundData>(PathConfig.GEM_SOUND_DATA);

            Data.Init();

            EventBus.Instance.RegisterListenerEvent(typeof(GemTakenEvent), new EventListener<GemTakenEvent>(OnGemTaken));
            EventBus.Instance.RegisterListenerEvent(typeof(GemDestroyedEvent), new EventListener<GemDestroyedEvent>(OnGemDestroyed));
        }

        private void OnGemTaken(GemTakenEvent data)
        {
            Data.AudioSource.PlayOneShot(Data.TakenSound);
        }

        private void OnGemDestroyed(GemDestroyedEvent data)
        {
            Data.AudioSource.PlayOneShot(Data.DestroySound);
        }
    }
}
