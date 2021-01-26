using UnityEngine;
using Krivodeling.Animation;

using Project.EventBusSystem;

namespace Project
{
    public class BackgroundEffect : MonoBehaviour
    {
        private TransformAnimator _animator;

        public Vector2 MinPositionRecoil = new Vector2(-0.05f, -0.05f);
        public Vector2 MaxPositionRecoil = new Vector2(0.05f, 0.05f);

        public float TrapPositionRecoil = 0.05f;

        private float one;

        private void Awake()
        {
            _animator = GetComponent<TransformAnimator>();

            EventBus.Instance.RegisterListenerEvent(typeof(GemTakenEvent), new EventListener<GemTakenEvent>(OnGemTaken));
            EventBus.Instance.RegisterListenerEvent(typeof(TrapTakenEvent), new EventListener<TrapTakenEvent>(OnTrapTaken));
            EventBus.Instance.RegisterListenerEvent(typeof(GemDestroyedEvent), new EventListener<GemDestroyedEvent>(OnGemDestroyed));
        }

        private void OnGemTaken(GemTakenEvent data)
        {
            PlayCorrectAnimation();
        }

        private void OnTrapTaken(TrapTakenEvent data)
        {
            PlayWrongAnimation();
        }

        private void OnGemDestroyed(GemDestroyedEvent data)
        {
            PlayWrongAnimation();
        }

        private void PlayCorrectAnimation()
        {
            _animator.Animation.Move.By.x = Random.Range(MinPositionRecoil.x, MaxPositionRecoil.x);
            _animator.Animation.Move.By.y = Random.Range(MinPositionRecoil.y, MaxPositionRecoil.y);

            _animator.Play();
        }

        private void PlayWrongAnimation()
        {
            one = Random.One();

            _animator.Animation.Move.By.x = TrapPositionRecoil * one;
            _animator.Animation.Move.By.y = TrapPositionRecoil * one;

            _animator.Play();
        }
    }
}
