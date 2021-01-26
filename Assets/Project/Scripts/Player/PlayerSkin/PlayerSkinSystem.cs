using System.Collections.Generic;

using Project.Components;
using Project.EventBusSystem;

namespace Project.Systems
{
    internal sealed class PlayerSkinSystem : SystemBase
    {
        private PlayerSkinInfo Info => PlayerSkinInfo.Instance;

        private PlayerSkinComponent Current;

        private bool lastSkinWasSetted;

        protected override void OnCreate()
        {
            Current = (PlayerSkinComponent)Entities.Instance.With<PlayerSkinComponent>()[0];

            EventBus.Instance.RegisterListenerEvent(typeof(NewRecordEvent), new EventListener<NewRecordEvent>(OnNewRecord));
            EventBus.Instance.RegisterListenerEvent(typeof(PlayerSkinChangeEvent), new EventListener<PlayerSkinChangeEvent>(OnPlayerSkinChange));

            SetSkin(Info.LastSkin);

            lastSkinWasSetted = true;
        }

        private void OnNewRecord(NewRecordEvent data)
        {
            if (Info.Data == null)
                return;

            List<PlayerSkinData> avaiableSkins = new List<PlayerSkinData>();
            PlayerSkinData maxSkin = null;

            for (int i = 0; i < Info.Data.Length; i++)
                if (Info.Data[i].Price <= data.NewRecord)
                    avaiableSkins.Add(Info.Data[i]);

            for (int i = 0; i < avaiableSkins.Count; i++)
            {
                if (i == 0)
                    maxSkin = avaiableSkins[i];

                if (avaiableSkins[i].Price > maxSkin.Price)
                    maxSkin = avaiableSkins[i];
            }

            if (maxSkin != null && lastSkinWasSetted)
            {
                SetSkin(maxSkin);

                EventBus.Instance.PostEvent(new PlayerSkinAvaiableEvent());
            }
        }

        private void OnPlayerSkinChange(PlayerSkinChangeEvent data)
        {
            SetSkin(data.Data);
        }

        private void SetSkin(PlayerSkinData data)
        {
            Current.SpriteRenderer.sprite = data.Sprite;
        }
    }
}
