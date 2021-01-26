using UnityEngine;

using Project.Components;

namespace Project.Systems
{
    internal sealed class RippleSystem : SystemBase, IUpdatable
    {
        private RippleComponent Current;

        private float scaleDeformationSpeed = 0.16f;
        private float currentScaleDeformationSpeed;
        private Color dissolutionColor;
        private Vector3 deformationScale;

        protected override void OnCreate()
        {
            Components = Entities.Instance.With<RippleComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Current = (RippleComponent)Components[i];

                currentScaleDeformationSpeed = scaleDeformationSpeed * deltaTime;
                dissolutionColor.a = Current.DissolutionSpeed * deltaTime;
                deformationScale.x = currentScaleDeformationSpeed;
                deformationScale.y = currentScaleDeformationSpeed;

                Current.SpriteRenderer.color -= dissolutionColor;
                Current.Transform.localScale += deformationScale;

                if (Current.SpriteRenderer.color.a <= 0f)
                    Entities.Instance.DestroyPoolableEntity(Current.GameObject);
            }
        }
    }
}
