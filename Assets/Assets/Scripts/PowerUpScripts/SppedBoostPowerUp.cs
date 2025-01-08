using System.Collections;
using UnityEngine;

public class SppedBoostPowerUp : PowerUp
{
    [SerializeField] int timer = 2;

    PlayerController playerController;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            OnCollect(other.gameObject, gameManager);
        }
    }

    protected override void OnCollect(GameObject player, GameManager manager)
    {
        playerController = player.GetComponent<PlayerController>();
        playerController.Speed = 12.5f;
        playerController.indicator.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(PowerUpCountdownRoutine());

    }

    IEnumerator PowerUpCountdownRoutine()
    {
        int remainingTime = timer;
        while(remainingTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            remainingTime--;
            Debug.Log("Time left" + remainingTime);
        }

        playerController.Speed = 10.0f;
        playerController.indicator.SetActive(false);
        Destroy(gameObject);
    }
}
