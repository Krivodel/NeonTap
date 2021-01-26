using UnityEngine;

using Project.EventBusSystem;

namespace Project.Components
{
    public sealed class PlayerAreaBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EventBus.Instance.PostEvent(new PlayerAreaBorderEnteredEvent(collision.gameObject));
        }
    }
}
