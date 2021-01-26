using UnityEngine;
using System;
using DG.Tweening;
using static Krivodeling.Animation.TransformAnimatorUtility;

namespace Krivodeling.Animation
{
    #region Enums
    public enum AnimationType
    {
        Default,
        Loop,
        Punch,
        State
    }

    public enum EaseType
    {
        Ease,
        AnimationCurve
    }

    public enum AnimationAction
    {
        Move,
        Rotate,
        Scale
    }
    #endregion

    [Serializable]
    public class Move
    {
        #region Variables
        public AnimationType AnimationType;
        public bool Enabled;
        public Vector3 From, To, By;
        public bool UseCustomFromAndTo;
        public int Vibrato;
        public float Elasticity;
        public int NumberOfLoops;
        public LoopType LoopType;
        public EaseType EaseType;
        public Ease Ease;
        public AnimationCurve AnimationCurve;
        public float StartDelay;
        public float Duration;
        public bool IgnoreTimeScale;
        public bool SpeedBased;
        #endregion

        #region Constructors
        public Move(AnimationType animationType)
        {
            Reset(animationType);
        }

        public Move(AnimationType animationType,
                    bool enabled,
                    Vector3 from, Vector3 to, Vector3 by,
                    bool useCustomFromAndTo,
                    int vibrato, float elasticity,
                    int numberOfLoops, LoopType loopType,
                    EaseType easeType, Ease ease, AnimationCurve animationCurve,
                    float startDelay, float duration,
                    bool ignoreTimeScale, bool speedBased) : this(animationType)
        {
            AnimationType = animationType;
            Enabled = enabled;
            From = from;
            To = to;
            By = by;
            UseCustomFromAndTo = useCustomFromAndTo;
            Vibrato = vibrato;
            Elasticity = elasticity;
            NumberOfLoops = numberOfLoops;
            LoopType = loopType;
            EaseType = easeType;
            Ease = ease;
            AnimationCurve = new AnimationCurve(animationCurve.keys);
            StartDelay = startDelay;
            Duration = duration;
            IgnoreTimeScale = ignoreTimeScale;
            SpeedBased = speedBased;
        }
        #endregion

        #region Methods
        public void Reset(AnimationType animationType)
        {
            AnimationType = animationType;
            Enabled = DEFAULT_ANIMATION_ENABLED;
            From = Vector3.zero;
            To = Vector3.zero;
            By = Vector3.zero;
            UseCustomFromAndTo = DEFAULT_USE_CUSTOM_FROM_AND_TO;
            Vibrato = DEFAULT_VIBRATO;
            Elasticity = DEFAULT_ELASTICITY;
            NumberOfLoops = DEFAULT_NUMBER_OF_LOOPS;
            LoopType = DEFAULT_LOOP_TYPE;
            EaseType = DEFAULT_EASE_TYPE;
            Ease = DEFAULT_EASE;
            AnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
            StartDelay = DEFAULT_START_DELAY;
            Duration = DEFAULT_DURATION;
            IgnoreTimeScale = DEFAULT_IGNORE_TIME_SCALE;
            SpeedBased = DEFAULT_SPEED_BASED;
        }

        public Move Copy()
        {
            return new Move(AnimationType)
            {
                AnimationType = AnimationType,
                Enabled = Enabled,
                From = From,
                To = To,
                By = By,
                UseCustomFromAndTo = UseCustomFromAndTo,
                Vibrato = Vibrato,
                Elasticity = Elasticity,
                NumberOfLoops = NumberOfLoops,
                LoopType = LoopType,
                EaseType = EaseType,
                Ease = Ease,
                AnimationCurve = new AnimationCurve(AnimationCurve.keys),
                StartDelay = StartDelay,
                Duration = Duration,
                IgnoreTimeScale = IgnoreTimeScale,
                SpeedBased = SpeedBased
            };
        }
        #endregion
    }

    [Serializable]
    public class Rotate
    {
        #region Variables
        public AnimationType AnimationType;
        public bool Enabled;
        public Vector3 From, To, By;
        public bool UseCustomFromAndTo;
        public int Vibrato;
        public float Elasticity;
        public int NumberOfLoops;
        public LoopType LoopType;
        public RotateMode RotateMode;
        public EaseType EaseType;
        public Ease Ease;
        public AnimationCurve AnimationCurve;
        public float StartDelay;
        public float Duration;
        public bool IgnoreTimeScale;
        public bool SpeedBased;
        #endregion

        #region Constructors
        public Rotate(AnimationType animationType)
        {
            Reset(animationType);
        }

        public Rotate(AnimationType animationType,
                    bool enabled,
                      Vector3 from, Vector3 to, Vector3 by,
                      bool useCustomFromAndTo,
                      int vibrato, float elasticity,
                      int numberOfLoops, LoopType loopType, RotateMode rotateMode,
                      EaseType easeType, Ease ease, AnimationCurve animationCurve,
                      float startDelay, float duration,
                      bool ignoreTimeScale, bool speedBased) : this(animationType)
        {
            AnimationType = animationType;
            Enabled = enabled;
            From = from;
            To = to;
            By = by;
            UseCustomFromAndTo = useCustomFromAndTo;
            Vibrato = vibrato;
            Elasticity = elasticity;
            NumberOfLoops = numberOfLoops;
            LoopType = loopType;
            RotateMode = rotateMode;
            EaseType = easeType;
            Ease = ease;
            AnimationCurve = new AnimationCurve(animationCurve.keys);
            StartDelay = startDelay;
            Duration = duration;
            IgnoreTimeScale = ignoreTimeScale;
            SpeedBased = speedBased;
        }
        #endregion

        #region Methods
        public void Reset(AnimationType animationType)
        {
            AnimationType = animationType;
            Enabled = DEFAULT_ANIMATION_ENABLED;
            From = Vector3.zero;
            To = Vector3.zero;
            By = Vector3.zero;
            UseCustomFromAndTo = DEFAULT_USE_CUSTOM_FROM_AND_TO;
            Vibrato = DEFAULT_VIBRATO;
            Elasticity = DEFAULT_ELASTICITY;
            NumberOfLoops = DEFAULT_NUMBER_OF_LOOPS;
            LoopType = DEFAULT_LOOP_TYPE;
            RotateMode = DEFAULT_ROTATE_MODE;
            EaseType = DEFAULT_EASE_TYPE;
            Ease = DEFAULT_EASE;
            AnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
            StartDelay = DEFAULT_START_DELAY;
            Duration = DEFAULT_DURATION;
            IgnoreTimeScale = DEFAULT_IGNORE_TIME_SCALE;
            SpeedBased = DEFAULT_SPEED_BASED;
        }

        public Rotate Copy()
        {
            return new Rotate(AnimationType)
            {
                AnimationType = AnimationType,
                Enabled = Enabled,
                From = From,
                To = To,
                By = By,
                UseCustomFromAndTo = UseCustomFromAndTo,
                Vibrato = Vibrato,
                Elasticity = Elasticity,
                NumberOfLoops = NumberOfLoops,
                LoopType = LoopType,
                RotateMode = RotateMode,
                EaseType = EaseType,
                Ease = Ease,
                AnimationCurve = new AnimationCurve(AnimationCurve.keys),
                StartDelay = StartDelay,
                Duration = Duration,
                IgnoreTimeScale = IgnoreTimeScale,
                SpeedBased = SpeedBased
            };
        }
        #endregion
    }

    [Serializable]
    public class Scale
    {
        #region Variables
        public AnimationType AnimationType = AnimationType.Default;
        public bool Enabled;
        public Vector3 From, To, By;
        public bool UseCustomFromAndTo;
        public int Vibrato;
        public float Elasticity;
        public int NumberOfLoops;
        public LoopType LoopType;
        public EaseType EaseType;
        public Ease Ease;
        public AnimationCurve AnimationCurve;
        public float StartDelay;
        public float Duration;
        public bool IgnoreTimeScale;
        public bool SpeedBased;
        #endregion

        #region Constructors
        public Scale(AnimationType animationType)
        {
            Reset(animationType);
        }

        public Scale(AnimationType animationType,
                     bool enabled,
                     Vector3 from, Vector3 to, Vector3 by,
                     bool useCustomFromAndTo,
                     int vibrato, float elasticity,
                     int numberOfLoops, LoopType loopType,
                     EaseType easeType, Ease ease, AnimationCurve animationCurve,
                     float startDelay, float duration,
                     bool ignoreTimeScale, bool speedBased) : this(animationType)
        {
            AnimationType = animationType;
            Enabled = enabled;
            From = from;
            To = to;
            By = by;
            UseCustomFromAndTo = useCustomFromAndTo;
            Vibrato = vibrato;
            Elasticity = elasticity;
            NumberOfLoops = numberOfLoops;
            LoopType = loopType;
            EaseType = easeType;
            Ease = ease;
            AnimationCurve = new AnimationCurve(animationCurve.keys);
            StartDelay = startDelay;
            Duration = duration;
            IgnoreTimeScale = ignoreTimeScale;
            SpeedBased = speedBased;
        }
        #endregion

        #region Methods
        public void Reset(AnimationType animationType)
        {
            AnimationType = animationType;
            Enabled = DEFAULT_ANIMATION_ENABLED;
            From = Vector3.zero;
            To = Vector3.zero;
            By = Vector3.zero;
            UseCustomFromAndTo = DEFAULT_USE_CUSTOM_FROM_AND_TO;
            Vibrato = DEFAULT_VIBRATO;
            Elasticity = DEFAULT_ELASTICITY;
            NumberOfLoops = DEFAULT_NUMBER_OF_LOOPS;
            LoopType = DEFAULT_LOOP_TYPE;
            EaseType = DEFAULT_EASE_TYPE;
            Ease = DEFAULT_EASE;
            AnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
            StartDelay = DEFAULT_START_DELAY;
            Duration = DEFAULT_DURATION;
            IgnoreTimeScale = DEFAULT_IGNORE_TIME_SCALE;
            SpeedBased = DEFAULT_SPEED_BASED;
        }

        public Scale Copy()
        {
            return new Scale(AnimationType)
            {
                AnimationType = AnimationType,
                Enabled = Enabled,
                From = From,
                To = To,
                By = By,
                UseCustomFromAndTo = UseCustomFromAndTo,
                Vibrato = Vibrato,
                Elasticity = Elasticity,
                NumberOfLoops = NumberOfLoops,
                LoopType = LoopType,
                EaseType = EaseType,
                Ease = Ease,
                AnimationCurve = new AnimationCurve(AnimationCurve.keys),
                StartDelay = StartDelay,
                Duration = Duration,
                IgnoreTimeScale = IgnoreTimeScale,
                SpeedBased = SpeedBased
            };
        }
        #endregion
    }
}
