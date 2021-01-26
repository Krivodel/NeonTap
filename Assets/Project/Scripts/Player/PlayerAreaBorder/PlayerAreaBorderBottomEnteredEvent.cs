using UnityEngine;

namespace Project.EventBusSystem
{
    public readonly struct PlayerAreaBorderBottomEnteredEvent
    {
        public readonly GameObject GameObject;
        public readonly float VelocityMagnitude;

        public PlayerAreaBorderBottomEnteredEvent(GameObject gameObject, float velocityMagnitude)
        {
            GameObject = gameObject;
            VelocityMagnitude = velocityMagnitude;
        }
    }
}
