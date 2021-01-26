using UnityEngine;

using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class TrapSoundSystem : SystemBase
    {
        private TrapSoundData Data;

        protected override void OnCreate()
        {
            Data = Resources.Load<TrapSoundData>(PathConfig.TRAP_SOUND_DATA);

            Data.Init();

            EventBus.Instance.RegisterListenerEvent(typeof(TrapTakenEvent), new EventListener<TrapTakenEvent>(OnTrapTaken));
        }

        private void OnTrapTaken(TrapTakenEvent data)
        {
            Data.AudioSource.PlayOneShot(Data.TakenSound);
        }
    }
}
