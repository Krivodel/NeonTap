using UnityEngine;
using System.Collections;

namespace Project
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private const float DEFAULT_PAUSE_TIME = 0f;

        private bool isPause;
        private float lastTimeScale;

        private void Awake()
        {
            Instance = this;
        }

        public void Pause(float time)
        {
            if (isPause)
                return;

            lastTimeScale = Time.timeScale;

            Time.timeScale = 0f;

            isPause = true;

            if (time > DEFAULT_PAUSE_TIME)
                RemoveFromPauseAfterPause(time);
        }

        public void Pause()
        {
            Pause(DEFAULT_PAUSE_TIME);
        }

        public void RemoveFromPause()
        {
            if (!isPause)
                return;

            Time.timeScale = lastTimeScale;

            isPause = false;
        }

        private void RemoveFromPauseAfterPause(float time)
        {
            StartCoroutine(RemoveFromPauseAfterPauseCoroutine(time));
        }

        private IEnumerator RemoveFromPauseAfterPauseCoroutine(float time)
        {
            yield return new WaitForSeconds(time);

            RemoveFromPause();
        }
    }
}
