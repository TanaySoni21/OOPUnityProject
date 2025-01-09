using System.Collections;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] int timer = 2;

    public void ActivatePowerUp(PowerUp powerUp)
    {
        gameObject.SetActive(true);
        StartCoroutine(PowerUpCountdownRoutine(powerUp));
    }

    IEnumerator PowerUpCountdownRoutine(PowerUp powerUp)
    {
        int remainingTime = timer;
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            remainingTime--;
            Debug.Log("Time left" + remainingTime);
        }

        powerUp.DeactivateSelf();
        gameObject.SetActive(false);    
    }
}
