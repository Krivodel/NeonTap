using UnityEngine;
using System;
using System.Collections;

using Project.EventBusSystem;

namespace Project
{
    public class PowerUpHandler
    {
        private Coroutiner Coroutiner = new Coroutiner();

        private bool hasPowerUp;

        private IPowerUp lastPowerUp;

        private PowerUpHandler()
        {
            EventBus e = EventBus.Instance;

            e.Register<PrestopGameEvent>(OnPrestopGame);
            e.Register<PowerUpCollectedEvent>(OnPowerUpCollected);
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Awake()
        {
            new PowerUpHandler();
        }

        private void OnPrestopGame(PrestopGameEvent data)
        {
            StopAllPowerups();
        }

        private void OnPowerUpCollected(PowerUpCollectedEvent data)
        {
            data.PowerUp.OnActive();

            if (data.PowerUp.HasLifetime)
            {
                if (hasPowerUp)
                    StopPowerUp(lastPowerUp);

                data.PowerUp.OnActive();

                Coroutiner.StartCoroutine(
                    DisactiveCoroutine(
                        data.PowerUp.Lifetime * Time.timeScale, data.PowerUp.PrestopTime * Time.timeScale, data.PowerUp.OnDisactive));

                hasPowerUp = true;

                EventBus.Instance.PostEvent(new ColorGammaDataChangeEvent(data.PowerUp.ColorGammaData));
            }

            lastPowerUp = data.PowerUp;
        }

        private void StopPowerUp(IPowerUp powerUp)
        {
            Coroutiner.StopAllCoroutines();

            if (powerUp != null)
                lastPowerUp.OnDisactive();

            StopAllPowerups();
        }

        private void StopAllPowerups()
        {
            EventBus.Instance.PostEvent(new StopAllPowerUpsEvent());
        }

        private IEnumerator DisactiveCoroutine(float lifetime, float prestopTime, Action disactiveAction)
        {
            yield return new WaitForSeconds(lifetime - prestopTime);

            EventBus.Instance.PostEvent(new ColorGammaDataChangeEvent(ColorGammaData.Default));

            yield return new WaitForSeconds(prestopTime);

            disactiveAction();

            hasPowerUp = false;
        }
    }
}
