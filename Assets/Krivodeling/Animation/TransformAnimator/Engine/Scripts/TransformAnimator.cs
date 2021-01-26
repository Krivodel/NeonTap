using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using static Krivodeling.Animation.TransformAnimatorUtility;
using System;

namespace Krivodeling.Animation
{
    public class TransformAnimator : MonoBehaviour
    {
        #region Variables
        public Vector3 StartPosition;
        public Vector3 StartRotation;
        public Vector3 StartScale;

        public TransformAnimation MainAnimation = new TransformAnimation();
        public TransformAnimation Animation = new TransformAnimation();

        public bool PlayAtStart = true;
        public bool InstantAction = false;

        public bool IsPlaying;
        #endregion

        #region Events
        public UnityEvent onStartMove, onCompleteMove;
        public UnityEvent onStartRotate, onCompleteRotate;
        public UnityEvent onStartScale, onCompleteScale;
        #endregion

        #region Methods
        private void Awake()
        {
            SetMainAnimation(Animation);
            UpdateStartValues();
        }

        private void Start()
        {
            if (PlayAtStart)
                Play();
        }

        public void ResetToStartValues()
        {
            ResetPosition();
            ResetRotation();
            ResetScale();
        }

        public void ResetPosition() => transform.position = StartPosition;

        public void ResetRotation() => transform.localEulerAngles = StartRotation;

        public void ResetScale() => transform.localScale = StartScale;

        public void UpdateStartValues()
        {
            UpdatePosition();
            UpdateRotation();
            UpdateScale();
        }

        public void UpdatePosition() => StartPosition = transform.position;

        public void UpdateRotation() => StartRotation = transform.localEulerAngles;

        public void UpdateScale() => StartScale = transform.localScale;

        [ContextMenu("Reset Move", false, 1)]
        public void ResetAnimationMove() => Animation.Move.Reset(DEFAULT_ANIMATION_TYPE);

        [ContextMenu("Reset Rotate", false, 1)]
        public void ResetAnimationRotate() => Animation.Rotate.Reset(DEFAULT_ANIMATION_TYPE);

        [ContextMenu("Reset Scale", false, 1)]
        public void ResetAnimationScale() => Animation.Scale.Reset(DEFAULT_ANIMATION_TYPE);

        public void Play(string preset = "", bool stop = true)
        {
            if (stop)
                Stop();

            if (preset != "")
                LoadPreset(preset);

            if (Animation.Move.Enabled)
            {
                switch (Animation.Move.AnimationType)
                {
                    case AnimationType.Default:
                        MoveDefault(
                            transform,
                            Animation,
                            Animation.Move.UseCustomFromAndTo ? Animation.Move.From : StartPosition,
                            Animation.Move.UseCustomFromAndTo ? Animation.Move.To : Animation.Move.By,
                            InstantAction,
                            () => onStartMove?.Invoke(),
                            () => onCompleteMove?.Invoke()
                            );
                        break;

                    case AnimationType.Loop:
                        MoveLoop(
                            transform,
                            Animation,
                            Animation.Move.UseCustomFromAndTo ? Animation.Move.From : StartPosition,
                            () => onStartMove?.Invoke(),
                            () => onCompleteMove?.Invoke()
                            );
                        break;

                    case AnimationType.Punch:
                        MovePunch(
                            transform,
                            Animation,
                            Animation.Move.UseCustomFromAndTo ? Animation.Move.From : StartPosition,
                            () => onStartMove?.Invoke(),
                            () => onCompleteMove?.Invoke()
                            );
                        break;

                    case AnimationType.State:
                        MoveState(
                            transform,
                            Animation,
                            Animation.Move.UseCustomFromAndTo ? Animation.Move.From : StartPosition,
                            () => onStartMove?.Invoke(),
                            () => onCompleteMove?.Invoke()
                            );
                        break;
                }
            }

            if (Animation.Rotate.Enabled)
            {
                switch (Animation.Rotate.AnimationType)
                {
                    case AnimationType.Default:
                        RotateDefault(
                            transform,
                            Animation,
                            Animation.Rotate.UseCustomFromAndTo ? Animation.Rotate.From : StartRotation,
                            Animation.Rotate.UseCustomFromAndTo ? Animation.Rotate.To : Animation.Rotate.By,
                            InstantAction,
                            () => onStartRotate?.Invoke(),
                            () => onCompleteRotate?.Invoke()
                            );
                        break;

                    case AnimationType.Loop:
                        RotateLoop(
                            transform,
                            Animation,
                            Animation.Rotate.UseCustomFromAndTo ? Animation.Rotate.From : StartRotation,
                            () => onStartRotate?.Invoke(),
                            () => onCompleteRotate?.Invoke()
                            );
                        break;

                    case AnimationType.Punch:
                        RotatePunch(
                            transform,
                            Animation,
                            Animation.Rotate.UseCustomFromAndTo ? Animation.Rotate.From : StartRotation,
                            () => onStartRotate?.Invoke(),
                            () => onCompleteRotate?.Invoke()
                            );
                        break;

                    case AnimationType.State:
                        RotateState(
                            transform,
                            Animation,
                            Animation.Rotate.UseCustomFromAndTo ? Animation.Rotate.From : StartRotation,
                            () => onStartRotate?.Invoke(),
                            () => onCompleteRotate?.Invoke()
                            );
                        break;
                }
            }

            if (Animation.Scale.Enabled)
            {
                switch (Animation.Scale.AnimationType)
                {
                    case AnimationType.Default:
                        ScaleDefault(
                            transform,
                            Animation,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.From : StartScale,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.To : Animation.Scale.By,
                            InstantAction,
                            () => onStartScale?.Invoke(),
                            () => onCompleteScale?.Invoke()
                            );
                        break;

                    case AnimationType.Loop:
                        ScaleLoop(
                            transform,
                            Animation,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.From : StartScale,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.To : Animation.Scale.By,
                            () => onStartScale?.Invoke(),
                            () => onCompleteScale?.Invoke()
                            );
                        break;

                    case AnimationType.Punch:
                        ScalePunch(
                            transform,
                            Animation,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.From : StartScale,
                            () => onStartScale?.Invoke(),
                            () => onCompleteScale?.Invoke()
                            );
                        break;

                    case AnimationType.State:
                        ScaleState(
                            transform,
                            Animation,
                            Animation.Scale.UseCustomFromAndTo ? Animation.Scale.From : StartScale,
                            () => onStartScale?.Invoke(),
                            () => onCompleteScale?.Invoke()
                            );
                        break;
                }
            }

            IsPlaying = true;
        }

        public void Play(TransformAnimation animation)
        {
            SetAnimation(animation);

            Play();
        }

        /// <summary>Punch | Default | State AnimationType only</summary>
        public void PlayOneShot(TransformAnimation animation, Action onComplete = null, bool isLast = false)
        {
            StopAllCoroutines();

            Play(animation);

            StartCoroutine(PlayOneShotCoroutine(animation, onComplete, isLast));
        }

        /// <summary>Punch | Default | State AnimationType only</summary>
        public void PlayOneShot(string presetName, Action onComplete = null)
        {
            PlayOneShot(TransformAnimatorPresets.GetPresetByName(presetName).Animation.Copy(), onComplete);
        }

        private IEnumerator PlayOneShotCoroutine(TransformAnimation animation, Action onComplete, bool isLast)
        {
            yield return new WaitForSeconds(animation.MaxDuration);

            if (onComplete != null)
                onComplete?.Invoke();

            if (isLast)
                yield break;

            Animation = MainAnimation.Copy();

            Play();
        }

        public void Stop(bool complete = true)
        {
            StopAnimations(transform, complete);

            IsPlaying = false;
        }

        public void SetMainAnimation(TransformAnimation animation)
        {
            MainAnimation = animation;
        }

        public void SetAnimation(TransformAnimation animation)
        {
            Animation = animation;
        }

        public void LoadPreset(TransformAnimatorPreset preset)
        {
            SetAnimation(preset.Animation.Copy());
        }

        public void LoadPreset(string name)
        {
            LoadPreset(TransformAnimatorPresets.GetPresetByName(name));
        }
        #endregion
    }
}
