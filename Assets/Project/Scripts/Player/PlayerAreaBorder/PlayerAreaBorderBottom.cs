using UnityEngine;

using Project.EventBusSystem;

namespace Project
{
    public class PlayerAreaBorderBottom : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            EventBus.Instance.PostEvent(new PlayerAreaBorderBottomEnteredEvent(collision.gameObject, collision.relativeVelocity.magnitude));
        }
    }
}
