using UnityEngine;
using System.Collections;

namespace Project
{
    public class DestroyAtTime : MonoBehaviour
    {
        private GameObject _gameObject;

        public bool IsPoolable = true;
        public float Lifetime = 8f;

        private void Awake()
        {
            _gameObject = gameObject;
        }

        private void Start()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(Lifetime);

            if (IsPoolable)
                Entities.Instance.DestroyPoolableEntity(_gameObject);
            else
                Destroy(_gameObject);
        }
    }
}
