using UnityEngine;
using System.Collections;

using Project.Addons;

namespace Project
{
    public class Coroutiner
    {
        private readonly CoroutinerAddon _coroutinerAddon;

        public Coroutiner()
        {
            _coroutinerAddon = CoroutinerAddon.Create();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _coroutinerAddon.StartCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            _coroutinerAddon.StopCoroutine(routine);
        }

        public void StopCoroutine(IEnumerator routine)
        {
            _coroutinerAddon.StopCoroutine(routine);
        }

        public void StopAllCoroutines()
        {
            _coroutinerAddon.StopAllCoroutines();
        }
    }
}
