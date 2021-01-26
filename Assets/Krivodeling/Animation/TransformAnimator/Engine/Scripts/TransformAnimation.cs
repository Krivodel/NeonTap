using System;

namespace Krivodeling.Animation
{
    [Serializable]
    public class TransformAnimation
    {
        #region Variables
        public float MaxDuration => Math.Max(Move.Duration, Math.Max(Rotate.Duration, Scale.Duration));

        public Move Move;
        public Rotate Rotate;
        public Scale Scale;
        #endregion

        #region Constructors
        public TransformAnimation()
        {
            Reset();
        }

        public TransformAnimation(Move move, Rotate rotate, Scale scale) : this()
        {
            Move = move;
            Rotate = rotate;
            Scale = scale;
        }
        #endregion

        #region Methods
        public void Reset()
        {
            Move = new Move(TransformAnimatorUtility.DEFAULT_ANIMATION_TYPE);
            Rotate = new Rotate(TransformAnimatorUtility.DEFAULT_ANIMATION_TYPE);
            Scale = new Scale(TransformAnimatorUtility.DEFAULT_ANIMATION_TYPE);
        }

        public TransformAnimation Copy()
        {
            return new TransformAnimation()
            {
                Move = Move.Copy(),
                Rotate = Rotate.Copy(),
                Scale = Scale.Copy()
            };
        }
        #endregion
    }
}
