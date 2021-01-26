using UnityEngine;
using System;
using System.Collections.Generic;

using Project.Components;

using Object = UnityEngine.Object;

namespace Project
{
    public sealed class Entities
    {
        public static Entities Instance => _instance ?? (_instance = new Entities());
        private static Entities _instance;

        private readonly Dictionary<int, List<ComponentBase>> Dictionary = new Dictionary<int, List<ComponentBase>>();

        internal void RegisterComponent(int hash, ComponentBase value)
        {
            if (Dictionary.ContainsKey(hash))
                Dictionary[hash].Add(value);
            else
                Dictionary.Add(hash, new List<ComponentBase>() { value });
        }

        internal void UnregisterComponent(int hash, ComponentBase value)
        {
            if (Dictionary.ContainsKey(hash))
                Dictionary[hash].Remove(value);
        }

        public List<ComponentBase> With<T>()
        {
            int hash = typeof(T).GetHashCode();

            if (Dictionary.ContainsKey(hash))
                return Dictionary[hash];

            List<ComponentBase> result = new List<ComponentBase>();

            Dictionary.Add(hash, result);

            return result;
        }

        public GameObject CreateEntity(string name, params Type[] components)
        {
            return new GameObject(name, components);
        }

        public GameObject CreateEntity(string name)
        {
            return new GameObject(name);
        }

        public GameObject CreateEntity(params Type[] components)
        {
            return new GameObject("GameObject", components);
        }

        public GameObject CreateEntity()
        {
            return new GameObject();
        }

        public GameObject CreateEntity(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Object.Instantiate(original, position, rotation, parent);
        }

        public GameObject CreateEntity(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(original, position, rotation);
        }

        public GameObject CreateEntity(GameObject original, Vector3 position)
        {
            return Object.Instantiate(original, position, Quaternion.identity);
        }

        public GameObject CreateEntity(GameObject original, Quaternion rotation)
        {
            return Object.Instantiate(original, Vector3.zero, rotation);
        }

        public GameObject CreateEntity(GameObject original, Transform parent)
        {
            return Object.Instantiate(original, parent);
        }

        public GameObject CreateEntity(GameObject original)
        {
            return Object.Instantiate(original);
        }

        public void DestroyEntity(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }

#if POOL_ENTITIES
        public GameObject CreatePoolableEntity(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Pool.Instance.Get(original, position, rotation, parent);
        }

        public GameObject CreatePoolableEntity(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Pool.Instance.Get(original, position, rotation);
        }

        public GameObject CreatePoolableEntity(GameObject original, Vector3 position)
        {
            return Pool.Instance.Get(original, position, Quaternion.identity);
        }

        public GameObject CreatePoolableEntity(GameObject original, Quaternion rotation)
        {
            return Pool.Instance.Get(original, Vector3.zero, rotation);
        }

        public GameObject CreatePoolableEntity(GameObject original, Transform parent)
        {
            return Pool.Instance.Get(original, Vector3.zero, Quaternion.identity, parent);
        }

        public GameObject CreatePoolableEntity(GameObject original)
        {
            return Pool.Instance.Get(original, Vector3.zero, Quaternion.identity);
        }

        public void DestroyPoolableEntity(GameObject gameObject)
        {
            Pool.Instance.Put(gameObject);
        }
#endif
    }
}
