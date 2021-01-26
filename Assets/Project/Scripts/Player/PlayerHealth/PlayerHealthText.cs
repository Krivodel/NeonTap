using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class PlayerHealthText : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();

            EventBus.Instance.RegisterListenerEvent(
                typeof(PlayerHealthChangedEvent), new EventListener<PlayerHealthChangedEvent>(OnPlayerHealthChanged));
        }

        private void OnPlayerHealthChanged(PlayerHealthChangedEvent data)
        {
            _text.text = data.Health.ToString();
        }
    }
}
