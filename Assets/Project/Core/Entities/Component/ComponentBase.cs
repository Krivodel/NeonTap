using UnityEngine;

namespace Project.Components
{
    public abstract class ComponentBase : MonoBehaviour
    {
        private int _hash;

        protected virtual void OnEnable()
        {
            _hash = GetType().GetHashCode();

            Entities.Instance.RegisterComponent(_hash, this);
        }

        protected virtual void OnDisable()
        {
            Entities.Instance.UnregisterComponent(_hash, this);
        }
    }
}
