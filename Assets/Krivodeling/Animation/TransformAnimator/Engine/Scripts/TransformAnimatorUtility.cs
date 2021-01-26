using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace Krivodeling.Animation
{
    public static class TransformAnimatorUtility
    {
        #region Consts
        public const AnimationType DEFAULT_ANIMATION_TYPE = AnimationType.Loop;
        public const bool DEFAULT_ANIMATION_ENABLED = false;
        public const bool DEFAULT_USE_CUSTOM_FROM_AND_TO = false;
        public const RotateMode DEFAULT_ROTATE_MODE = RotateMode.Fast;
        public const LoopType DEFAULT_LOOP_TYPE = LoopType.Yoyo;
        public const EaseType DEFAULT_EASE_TYPE = EaseType.Ease;
        public const Ease DEFAULT_EASE = Ease.Linear;
        public const float DEFAULT_DURATION = 1f;
        public const float DEFAULT_START_DELAY = 0f;
        public const int DEFAULT_NUMBER_OF_LOOPS = -1;
        public const float DEFAULT_DURATION_ON_COMPLETE = 0.05f;
        public const int DEFAULT_VIBRATO = 10;
        public const float DEFAULT_ELASTICITY = 1f;
        public const bool DEFAULT_IGNORE_TIME_SCALE = false;
        public const bool DEFAULT_SPEED_BASED = false;
        #endregion

        #region Tweens
        #region Move
        public static Vector3 MoveLoopPositionA(TransformAnimation animation, Vector3 startValue) =>
            animation.Move.UseCustomFromAndTo ? (startValue - animation.Move.To) : (startValue - animation.Move.By);
        public static Vector3 MoveLoopPositionB(TransformAnimation animation, Vector3 startValue) =>
            animation.Move.UseCustomFromAndTo ? (startValue + animation.Move.To) : (startValue + animation.Move.By);

        public static Tween MoveDefaultTween(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue)
        {
            target.position = startValue;

            Tweener tween = target.DOMove(endValue, animation.Move.Duration)
                                  .SetDelay(animation.Move.StartDelay)
                                  .SetUpdate(animation.Move.IgnoreTimeScale)
                                  .SetSpeedBased(animation.Move.SpeedBased);

            tween.SetEase(animation.Move);

            return tween;
        }

        public static Tween MoveLoopTween(Transform target, TransformAnimation animation, Vector3 startValue)
        {
            Tween tween = target.DOMove(MoveLoopPositionB(animation, startValue), animation.Move.Duration)
                                    .SetUpdate(animation.Move.IgnoreTimeScale)
                                    .SetSpeedBased(animation.Move.SpeedBased)
                                    .SetLoops(animation.Move.NumberOfLoops, animation.Move.LoopType);

            tween.SetEase(animation.Move);

            return tween;
        }

        public static Tween MovePunchTween(Transform target, TransformAnimation animation)
        {
            return target.DOPunchPosition(animation.Move.By, animation.Move.Duration, animation.Move.Vibrato, animation.Move.Elasticity)
                         .SetDelay(animation.Move.StartDelay)
                         .SetUpdate(animation.Move.IgnoreTimeScale)
                         .SetSpeedBased(animation.Move.SpeedBased);
        }

        public static Tween MoveStateTween(Transform target, TransformAnimation animation, Vector3 startValue)
        {
            Tween tween = target.DOMove(startValue + animation.Move.By, animation.Move.Duration)
                                .SetDelay(animation.Move.StartDelay)
                                .SetUpdate(animation.Move.IgnoreTimeScale)
                                .SetSpeedBased(animation.Move.SpeedBased);

            tween.SetEase(animation.Move);

            return tween;
        }
        #endregion

        #region Rotate
        public static Vector3 RotateLoopRotationA(TransformAnimation animation, Vector3 startValue) =>
            animation.Rotate.UseCustomFromAndTo ? (startValue - animation.Rotate.To) : (startValue - animation.Rotate.By);
        public static Vector3 RotateLoopRotationB(TransformAnimation animation, Vector3 startValue) =>
            animation.Rotate.UseCustomFromAndTo ? (startValue + animation.Rotate.To) : (startValue + animation.Rotate.By);

        public static Tween RotateDefaultTween(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue)
        {
            target.localRotation = Quaternion.Euler(startValue);

            Tweener tween = target.DOLocalRotate(endValue, animation.Rotate.Duration, animation.Rotate.RotateMode)
                                  .SetDelay(animation.Rotate.StartDelay)
                                  .SetUpdate(animation.Rotate.IgnoreTimeScale)
                                  .SetSpeedBased(animation.Rotate.SpeedBased);

            tween.SetEase(animation.Rotate);

            return tween;
        }

        public static Tween RotateLoopTween(Transform target, TransformAnimation animation, Vector3 startValue)
        {
            Tween tween = target.DOLocalRotate(RotateLoopRotationB(animation, startValue), animation.Rotate.Duration, animation.Rotate.RotateMode)
                                    .SetUpdate(animation.Rotate.IgnoreTimeScale)
                                    .SetSpeedBased(animation.Rotate.SpeedBased)
                                    .SetLoops(animation.Rotate.NumberOfLoops, animation.Rotate.LoopType);

            tween.SetEase(animation.Rotate);

            return tween;
        }

        public static Tween RotatePunchTween(Transform target, TransformAnimation animation)
        {
            return target.DOPunchRotation(animation.Rotate.By, animation.Rotate.Duration, animation.Rotate.Vibrato, animation.Rotate.Elasticity)
                         .SetDelay(animation.Rotate.StartDelay)
                         .SetUpdate(animation.Rotate.IgnoreTimeScale)
                         .SetSpeedBased(animation.Rotate.SpeedBased);
        }

        public static Tween RotateStateTween(Transform target, TransformAnimation animation, Vector3 startValue)
        {
            Tween tween = target.DOLocalRotate(startValue + animation.Rotate.By, animation.Rotate.Duration, animation.Rotate.RotateMode)
                                .SetDelay(animation.Rotate.StartDelay)
                                .SetUpdate(animation.Rotate.IgnoreTimeScale)
                                .SetSpeedBased(animation.Rotate.SpeedBased);

            tween.SetEase(animation.Rotate);
            
            return tween;
        }
        #endregion

        #region Scale
        public static Tween ScaleDefaultTween(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue)
        {
            target.localScale = startValue;

            Tweener tween = target.DOScale(endValue, animation.Scale.Duration)
                                  .SetDelay(animation.Scale.StartDelay)
                                  .SetUpdate(animation.Scale.IgnoreTimeScale)
                                  .SetSpeedBased(animation.Scale.SpeedBased);

            tween.SetEase(animation.Scale);

            return tween;
        }

        public static Tween ScaleLoopTween(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue)
        {
            target.localScale = startValue;

            Tweener tween = target.DOScale(endValue, animation.Scale.Duration)
                                      .SetUpdate(animation.Scale.IgnoreTimeScale)
                                      .SetSpeedBased(animation.Scale.SpeedBased)
                                      .SetLoops(animation.Scale.NumberOfLoops, animation.Scale.LoopType);

            tween.SetEase(animation.Scale);

            return tween;
        }

        public static Tween ScalePunchTween(Transform target, TransformAnimation animation)
        {
            return target.DOPunchScale(animation.Scale.By, animation.Scale.Duration, animation.Scale.Vibrato, animation.Scale.Elasticity)
                         .SetDelay(animation.Scale.StartDelay)
                         .SetUpdate(animation.Scale.IgnoreTimeScale)
                         .SetSpeedBased(animation.Scale.SpeedBased);
        }

        public static Tween ScaleStateTween(Transform target, TransformAnimation animation, Vector3 startValue)
        {
            Tween tween = target.DOScale(startValue + animation.Scale.By, animation.Scale.Duration)
                                .SetDelay(animation.Scale.StartDelay)
                                .SetUpdate(animation.Scale.IgnoreTimeScale)
                                .SetSpeedBased(animation.Scale.SpeedBased);

            tween.SetEase(animation.Scale);

            return tween;
        }
        #endregion
        #endregion

        #region Animations
        #region Move
        public static void MoveDefault(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.Enabled)
                return;

            if (instantAction)
            {
                target.position = endValue;

                onStartCallback?.Invoke();
                onCompleteCallback?.Invoke();

                return;
            }

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Move))
                   .SetUpdate(animation.Move.IgnoreTimeScale)
                   .SetSpeedBased(animation.Move.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(MoveDefaultTween(target, animation, startValue, endValue))
                   .Play();
        }

        public static void MoveLoop(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.Enabled || animation.Move.AnimationType != AnimationType.Loop)
                return;

            Vector3 positionA = MoveLoopPositionA(animation, startValue);

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GetTweenId(target, AnimationAction.Move))
                                           .SetUpdate(animation.Move.IgnoreTimeScale)
                                           .SetSpeedBased(animation.Move.SpeedBased)
                                           .Append(MoveLoopTween(target, animation, startValue))
                                           .SetLoops(animation.Move.NumberOfLoops, animation.Move.LoopType)
                                           .OnComplete(() => onCompleteCallback?.Invoke())
                                           .OnKill(() => onCompleteCallback?.Invoke())
                                           .Pause();

            Tween startTween = target.DOMove(positionA, animation.Move.Duration / 2f)
                                     .SetDelay(animation.Move.StartDelay)
                                     .SetUpdate(animation.Move.IgnoreTimeScale)
                                     .SetSpeedBased(animation.Move.SpeedBased)
                                     .Pause();

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Move))
                   .SetUpdate(animation.Move.IgnoreTimeScale)
                   .SetSpeedBased(animation.Move.SpeedBased)
                   .Append(startTween)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => loopSequence.Play());
        }

        public static void MovePunch(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.Enabled || animation.Move.AnimationType != AnimationType.Punch)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Move))
                   .SetUpdate(animation.Move.IgnoreTimeScale)
                   .SetSpeedBased(animation.Move.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() =>
                   {
                       target.DOMove(startValue, DEFAULT_DURATION_ON_COMPLETE)
                             .OnComplete(() => onCompleteCallback?.Invoke())
                             .Play();
                   })
                   .Append(MovePunchTween(target, animation))
                   .Play();
        }

        public static void MoveState(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.Enabled || animation.Move.AnimationType != AnimationType.State)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Move))
                   .SetUpdate(animation.Move.IgnoreTimeScale)
                   .SetSpeedBased(animation.Move.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(MoveStateTween(target, animation, startValue))
                   .Play();
        }
        #endregion

        #region Rotate
        public static void RotateDefault(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Rotate.Enabled)
                return;

            if (instantAction)
            {
                target.localRotation = Quaternion.Euler(endValue);

                onStartCallback?.Invoke();
                onCompleteCallback?.Invoke();

                return;
            }

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Rotate))
                   .SetUpdate(animation.Rotate.IgnoreTimeScale)
                   .SetSpeedBased(animation.Rotate.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(RotateDefaultTween(target, animation, startValue, endValue))
                   .Play();
        }

        public static void RotateLoop(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Rotate.Enabled || animation.Rotate.AnimationType != AnimationType.Loop)
                return;

            Vector3 rotationA = RotateLoopRotationA(animation, startValue);

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GetTweenId(target, AnimationAction.Rotate))
                                           .SetUpdate(animation.Rotate.IgnoreTimeScale)
                                           .SetSpeedBased(animation.Rotate.SpeedBased)
                                           .Append(RotateLoopTween(target, animation, startValue))
                                           .SetLoops(animation.Rotate.NumberOfLoops, animation.Rotate.LoopType)
                                           .OnComplete(() => onCompleteCallback?.Invoke())
                                           .OnKill(() => onCompleteCallback?.Invoke())
                                           .Pause();

            Tween startTween = target.DOLocalRotate(rotationA, animation.Rotate.Duration / 2f, animation.Rotate.RotateMode)
                                     .SetDelay(animation.Rotate.StartDelay)
                                     .SetUpdate(animation.Rotate.IgnoreTimeScale)
                                     .SetSpeedBased(animation.Rotate.SpeedBased)
                                     .Pause();

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Rotate))
                   .SetUpdate(animation.Rotate.IgnoreTimeScale)
                   .SetSpeedBased(animation.Rotate.SpeedBased)
                   .Append(startTween)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => loopSequence.Play());
        }

        public static void RotatePunch(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Rotate.Enabled || animation.Rotate.AnimationType != AnimationType.Punch)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Rotate))
                   .SetUpdate(animation.Rotate.IgnoreTimeScale)
                   .SetSpeedBased(animation.Rotate.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() =>
                   {
                       target.DOLocalRotate(startValue, DEFAULT_DURATION_ON_COMPLETE)
                       .OnComplete(() => onCompleteCallback?.Invoke())
                       .Play();
                   })
                   .Append(RotatePunchTween(target, animation))
                   .Play();
        }

        public static void RotateState(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Rotate.Enabled || animation.Rotate.AnimationType != AnimationType.State)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Rotate))
                   .SetUpdate(animation.Rotate.IgnoreTimeScale)
                   .SetSpeedBased(animation.Rotate.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(RotateStateTween(target, animation, startValue))
                   .Play();
        }
        #endregion

        #region Scale
        public static void ScaleDefault(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue, bool instantAction = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Scale.Enabled)
                return;

            if (instantAction)
            {
                target.localScale = endValue;

                onStartCallback?.Invoke();
                onCompleteCallback?.Invoke();

                return;
            }

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Scale))
                   .SetUpdate(animation.Scale.IgnoreTimeScale)
                   .SetSpeedBased(animation.Scale.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(ScaleDefaultTween(target, animation, startValue, endValue))
                   .Play();
        }

        public static void ScaleLoop(Transform target, TransformAnimation animation, Vector3 startValue, Vector3 endValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Scale.Enabled || animation.Scale.AnimationType != AnimationType.Loop)
                return;

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GetTweenId(target, AnimationAction.Scale))
                                           .SetUpdate(animation.Scale.IgnoreTimeScale)
                                           .SetSpeedBased(animation.Scale.SpeedBased)
                                           .Append(ScaleLoopTween(target, animation, startValue, endValue))
                                           .SetLoops(animation.Scale.NumberOfLoops, animation.Scale.LoopType)
                                           .OnComplete(() => onCompleteCallback?.Invoke())
                                           .OnKill(() => onCompleteCallback?.Invoke())
                                           .Pause();

            Tween startTween = target.DOScale(startValue, animation.Scale.Duration / 2f)
                                     .SetDelay(animation.Scale.StartDelay)
                                     .SetUpdate(animation.Scale.IgnoreTimeScale)
                                     .SetSpeedBased(animation.Scale.SpeedBased)
                                     .Pause();

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Scale))
                   .SetUpdate(animation.Scale.IgnoreTimeScale)
                   .SetSpeedBased(animation.Scale.SpeedBased)
                   .Append(startTween)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => loopSequence.Play());
        }

        public static void ScalePunch(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Scale.Enabled || animation.Scale.AnimationType != AnimationType.Punch)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Scale))
                   .SetUpdate(animation.Scale.IgnoreTimeScale)
                   .SetSpeedBased(animation.Scale.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() =>
                   {
                       target.DOScale(startValue, DEFAULT_DURATION_ON_COMPLETE)
                       .OnComplete(() => onCompleteCallback?.Invoke())
                       .Play();
                   })
                   .Append(ScalePunchTween(target, animation))
                   .Play();
        }

        public static void ScaleState(Transform target, TransformAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Scale.Enabled || animation.Scale.AnimationType != AnimationType.State)
                return;

            DOTween.Sequence()
                   .SetId(GetTweenId(target, AnimationAction.Scale))
                   .SetUpdate(animation.Scale.IgnoreTimeScale)
                   .SetSpeedBased(animation.Scale.SpeedBased)
                   .OnStart(() => onStartCallback?.Invoke())
                   .OnComplete(() => onCompleteCallback?.Invoke())
                   .Append(ScaleStateTween(target, animation, startValue))
                   .Play();
        }
        #endregion
        #endregion

        #region HelperMethods
        public static string GetTweenId(Transform target, AnimationAction animationAction)
            => target.GetInstanceID() + "-" + animationAction;

        public static void StopAnimations(Transform target, bool complete)
        {
            if (target == null)
                return;

            DOTween.Kill(GetTweenId(target, AnimationAction.Move), complete);
            DOTween.Kill(GetTweenId(target, AnimationAction.Rotate), complete);
            DOTween.Kill(GetTweenId(target, AnimationAction.Scale), complete);
        }
        #endregion

        #region Extensions
        private static void SetEase(this Tween tween, Move move)
        {
            switch (move.EaseType)
            {
                case EaseType.Ease:
                    tween.SetEase(move.Ease);
                    break;
                case EaseType.AnimationCurve:
                    tween.SetEase(move.AnimationCurve);
                    break;
            }
        }

        private static void SetEase(this Tween tween, Rotate rotate)
        {
            switch (rotate.EaseType)
            {
                case EaseType.Ease:
                    tween.SetEase(rotate.Ease);
                    break;
                case EaseType.AnimationCurve:
                    tween.SetEase(rotate.AnimationCurve);
                    break;
            }
        }

        private static void SetEase(this Tween tween, Scale scale)
        {
            switch (scale.EaseType)
            {
                case EaseType.Ease:
                    tween.SetEase(scale.Ease);
                    break;
                case EaseType.AnimationCurve:
                    tween.SetEase(scale.AnimationCurve);
                    break;
            }
        }
        #endregion
    }
}
