using Project.EventBusSystem;

namespace Project
{
    public class PowerUpShield : PowerUp
    {
        public override void OnActive()
        {
            base.OnActive();

            PlayerInfo.Instance.IsInvulnerable = true;

            EventBus.Instance.PostEvent(new PowerUpShieldActivatedEvent());
        }

        public override void OnDisactive()
        {
            base.OnDisactive();

            PlayerInfo.Instance.IsInvulnerable = false;

            EventBus.Instance.PostEvent(new PowerUpShieldDisactivatedEvent());
        }
    }
}
