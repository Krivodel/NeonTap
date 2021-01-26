using Project.EventBusSystem;

namespace Project
{
    public class PowerUpInvert : PowerUp
    {
        public override void OnActive()
        {
            base.OnActive();

            PlayerInfo.Instance.IsInvert = true;

            EventBus.Instance.PostEvent(new PowerUpInvertActivatedEvent());
        }

        public override void OnDisactive()
        {
            base.OnDisactive();

            PlayerInfo.Instance.IsInvert = false;

            EventBus.Instance.PostEvent(new PowerUpInvertDisactivatedEvent());
        }
    }
}
