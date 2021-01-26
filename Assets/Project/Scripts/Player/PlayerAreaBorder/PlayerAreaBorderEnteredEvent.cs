using UnityEngine;

namespace Project.EventBusSystem
{
    public readonly struct PlayerAreaBorderEnteredEvent
    {
        public readonly GameObject GameObject;

        public PlayerAreaBorderEnteredEvent(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}
