using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

namespace Project.Systems
{
    internal sealed class SystemRegistrator
    {
        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type interfaceType = typeof(IRegistrableSystem);

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly
                    .GetTypes()
                    .Where(type => type.GetInterfaces().Contains(interfaceType) && !type.IsAbstract))
                {
                    type.GetConstructors()[0].Invoke(null);
                }
            }
        }
    }
}
