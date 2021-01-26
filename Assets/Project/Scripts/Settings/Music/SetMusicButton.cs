using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class SetMusicButton : MonoBehaviour
    {
        private Image _image;

        public Sprite MusicOn;
        public Sprite MusicOff;

        private bool value;

        private void Awake()
        {
            _image = GetComponent<Image>();

            GetComponent<Button>().onClick.AddListener(OnClick);

            value = Settings.Instance.GetMusic();

            SetSprite();
        }

        private void OnClick()
        {
            value = !value;

            Settings.Instance.SetMusic(value);

            SetSprite();
        }

        private void SetSprite()
        {
            _image.sprite = value ? MusicOn : MusicOff;
        }
    }
}
