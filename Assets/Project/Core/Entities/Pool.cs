#define POOL_ENTITIES
using UnityEngine;
using System.Collections.Generic;

namespace Project
{
    internal sealed class Pool : ILevelWasLoaded
    {
        internal static Pool Instance => _instance ?? (_instance = new Pool());
        private static Pool _instance;

        private readonly Dictionary<string, LinkedList<GameObject>> Dictionary = new Dictionary<string, LinkedList<GameObject>>();

        private GameObject result;
        private string name;

        public void OnLevelWasLoaded(int level)
        {
            Clear();
        }

        internal GameObject Get(GameObject original, Vector3 position, Quaternion rotation, Transform parent)
        {
            name = original.name;

            if (!Dictionary.ContainsKey(name))
                Dictionary[name] = new LinkedList<GameObject>();

            result = null;

            if (Dictionary[name].Count > 0)
            {
                if (Dictionary[name].First.Value != null)
                {

                    result = Dictionary[name].First.Value;
                    Dictionary[name].RemoveFirst();

                    SetTransformValues(result.transform, position, rotation, parent);

                    result.SetActive(true);

                    return result;
                }
            }

            result = Object.Instantiate(original);

            SetTransformValues(result.transform, position, rotation, parent);
            result.name = name;

            return result;
        }

        internal GameObject Get(GameObject original, Vector3 position, Quaternion rotation)
        {
            return Get(original, position, rotation, null);
        }

        internal void Put(GameObject gameObject)
        {
            name = gameObject.name;

            if (!Dictionary.ContainsKey(name))
                Dictionary[name] = new LinkedList<GameObject>();

            if (Dictionary[name].Contains(gameObject))
                return;

            Dictionary[name].AddFirst(gameObject);

            gameObject.SetActive(false);
        }

        private void SetTransformValues(Transform transform, Vector3 position, Quaternion rotation, Transform parent)
        {
            transform.position = position;
            transform.rotation = rotation;

            if (transform.parent != parent)
                transform.parent = parent;
        }

        public void Clear()
        {
            Dictionary.Clear();
        }
    }
}
