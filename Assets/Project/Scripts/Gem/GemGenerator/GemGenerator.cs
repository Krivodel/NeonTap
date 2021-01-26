using UnityEngine;
using System;
using System.Collections;

using Project.EventBusSystem;

namespace Project
{
    public class GemGenerator : MonoBehaviour
    {
        public GameObject[] GemPrefabs;
        public GameObject[] PowerUpGemPrefabs;

        public Vector2 MinSpawnArea = new Vector2(-2.25f, 8f);
        public Vector2 MaxSpawnArea = new Vector2(2.25f, 10f);
        public float MinTime = 1f;
        public float MaxTime = 3f;

        private bool isPlaying;

        private bool isPowerUp;
        private bool isPowerUpIndex;
        private int lastGemIndex;
        private int lastPowerUpGemIndex;

        private void Awake()
        {
            EventBus e = EventBus.Instance;

            e.Register<StartGameEvent>(OnStartGame);
            e.Register<PrestopGameEvent>(OnPrestopGame);
            e.Register<StopGameEvent>(OnStopGame);
            e.Register<SuspendGemGeneratorEvent>(OnSuspendGemGenerator);
            e.Register<PlayerHealthRecoveredEvent>(OnPlayerHealthRecovered);
            e.Register<PowerUpActivatedEvent>(OnPowerUpActivated);
            e.Register<PowerUpDisactivatedEvent>(OnPowerUpDisactivated);
            e.Register<PowerUpInvertActivatedEvent>(OnPowerUpInvertActivated);
            e.Register<StopAllPowerUpsEvent>(OnStopAllPowerUps);
        }

        private void OnStartGame(StartGameEvent data)
        {
            SuspendGenerate(1f, true);
        }

        private void OnPrestopGame(PrestopGameEvent data)
        {
            StopGenerate();
        }

        private void OnStopGame(StopGameEvent data)
        {
            StopGenerate();
        }

        private void OnSuspendGemGenerator(SuspendGemGeneratorEvent data)
        {
            SuspendGenerate(data.Time, isPlaying);
        }

        private void OnPlayerHealthRecovered(PlayerHealthRecoveredEvent data)
        {
            StartGenerate();
        }

        private void OnPowerUpActivated(PowerUpActivatedEvent data)
        {
            isPowerUp = true;
        }

        private void OnPowerUpDisactivated(PowerUpDisactivatedEvent data)
        {
            isPowerUp = false;
        }

        private void OnPowerUpInvertActivated(PowerUpInvertActivatedEvent data)
        {
            SuspendGenerate(1f, true);
        }

        private void OnStopAllPowerUps(StopAllPowerUpsEvent data)
        {
            isPowerUp = false;
            isPowerUpIndex = false;
        }

        private void SuspendGenerate(float time, bool returnStart)
        {
            StopGenerate();

            if (returnStart)
                StartCoroutine(SuspendCoroutine(time));
        }

        private IEnumerator SuspendCoroutine(float time)
        {
            yield return new WaitForSeconds(time);

            StartGenerate();
        }

        private void StartGenerate()
        {
            isPlaying = true;

            StartCoroutine(GenerateCoroutine());
        }

        private void StopGenerate()
        {
            StopAllCoroutines();

            isPlaying = false;
            lastGemIndex = -1;
            lastPowerUpGemIndex = -1;
        }

        private GameObject GetRandomGemPrefab()
        {
            int index = GetRandomGemIndex();

            if (isPowerUpIndex)
                return PowerUpGemPrefabs[index];
            else
                return GemPrefabs[index];
        }

        private int GetRandomGemIndex()
        {
            int index;
            int rnd = (Environment.TickCount + 9728) % 5;

            if (rnd != 0 || isPowerUp)
            {
                index = Environment.TickCount % GemPrefabs.Length;

                if (index == lastGemIndex)
                    if (index == GemPrefabs.Length - 1)
                        index = 0;
                    else
                        index++;

                isPowerUpIndex = false;
                lastGemIndex = index;
            }
            else
            {
                index = Environment.TickCount % PowerUpGemPrefabs.Length;

                if (index == lastPowerUpGemIndex)
                    if (index == PowerUpGemPrefabs.Length - 1)
                        index = 0;
                    else
                        index++;

                isPowerUp = true;
                isPowerUpIndex = true;
                lastPowerUpGemIndex = index;
            }

            return index;
        }

        private Vector3 GetRandomGemPosition()
        {
            return new Vector3(
                Random.Range(MinSpawnArea.x, MaxSpawnArea.x),
                Random.Range(MinSpawnArea.y, MaxSpawnArea.y),
                0f);
        }

        private IEnumerator GenerateCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));

            Entities.Instance.CreatePoolableEntity(GetRandomGemPrefab(), GetRandomGemPosition());

            StartCoroutine(GenerateCoroutine());
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(MinSpawnArea, MaxSpawnArea);

            Gizmos.color = Color.white;
        }
#endif
    }
}
