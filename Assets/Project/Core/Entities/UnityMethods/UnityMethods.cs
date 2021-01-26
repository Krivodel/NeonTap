using UnityEngine;
using System.Collections.Generic;

namespace Project
{
    public class UnityMethods : MonoBehaviour
    {
        public static UnityMethods Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("[UnityMethodsManager]").AddComponent<UnityMethods>();

                    _instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
                }

                return _instance;
            }
        }
        private static UnityMethods _instance;

        private readonly List<IUpdatable> _updates = new List<IUpdatable>();
        private readonly List<ILateUpdatable> _lateUpdates = new List<ILateUpdatable>();
        private readonly List<IFixedUpdatable> _fixedUpdates = new List<IFixedUpdatable>();
        private readonly List<ILevelWasLoaded> _levelWasLoaded = new List<ILevelWasLoaded>();
        private readonly List<IOnApplicationQuit> _onApplicationQuit = new List<IOnApplicationQuit>();

        private float deltaTime, fixedDeltaTime;

        public void Register(object value)
        {
            if ((value as IUpdatable) != null)
                _updates.Add((IUpdatable)value);

            if ((value as ILateUpdatable) != null)
                _lateUpdates.Add((ILateUpdatable)value);

            if ((value as IFixedUpdatable) != null)
                _fixedUpdates.Add((IFixedUpdatable)value);

            if ((value as IOnApplicationQuit) != null)
                _onApplicationQuit.Add((IOnApplicationQuit)value);
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            deltaTime = Time.deltaTime;

            for (int i = 0; i < _updates.Count; i++)
                _updates[i].OnUpdate(deltaTime);
        }

        private void LateUpdate()
        {
            deltaTime = Time.deltaTime;

            for (int i = 0; i < _lateUpdates.Count; i++)
                _lateUpdates[i].OnLateUpdate(deltaTime);
        }

        private void FixedUpdate()
        {
            fixedDeltaTime = Time.fixedDeltaTime;

            for (int i = 0; i < _fixedUpdates.Count; i++)
                _fixedUpdates[i].OnFixedUpdate(fixedDeltaTime);
        }

        private void OnLevelWasLoaded(int level)
        {
            for (int i = 0; i < _levelWasLoaded.Count; i++)
                _levelWasLoaded[i].OnLevelWasLoaded(level);
        }

        private void OnApplicationQuit()
        {
            for (int i = 0; i < _onApplicationQuit.Count; i++)
                _onApplicationQuit[i].OnApplicationQuit();
        }
    }
}
