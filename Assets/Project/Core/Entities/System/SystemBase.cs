using System.Collections.Generic;

using Project.Components;

namespace Project.Systems
{
    public abstract class SystemBase : IRegistrableSystem
    {
        protected List<ComponentBase> Components;

        protected SystemBase()
        {
            UnityMethods.Instance.Register(this);

            OnCreate();
        }

        protected virtual void OnCreate() { }
    }
}
