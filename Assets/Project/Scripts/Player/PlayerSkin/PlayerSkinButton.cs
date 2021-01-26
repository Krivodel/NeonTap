using UnityEngine;
using UnityEngine.UI;

using Project.EventBusSystem;

namespace Project
{
    public class PlayerSkinButton : MonoBehaviour
    {
        private Image _image;

        public Text PriceText;

        public PlayerSkinData Data;

        public Color AvaiableColor = Color.green;
        public Color NotAvaiableColor = Color.red;

        private void Awake()
        {
            _image = GetComponent<Image>();

            GetComponent<Button>().onClick.AddListener(OnClick);

            EventBus.Instance.Register<PlayerSkinAvaiableEvent>(OnPlayerSkinAvaiable);

            UpdateUI();
        }

        private void OnClick()
        {
            if (IsAvaiable())
                EventBus.Instance.PostEvent(new PlayerSkinChangeEvent(Data));
        }

        private void OnPlayerSkinAvaiable(PlayerSkinAvaiableEvent data)
        {
            UpdateUI();
        }

        private bool IsAvaiable()
        {
            return RecordInfo.Instance.LastRecord >= Data.Price;
        }

        private void UpdateUI()
        {
            _image.sprite = Data.Sprite;
            PriceText.text = Data.Price.ToString();

            if (IsAvaiable())
                PriceText.color = AvaiableColor;
            else
                PriceText.color = NotAvaiableColor;
        }
    }
}
