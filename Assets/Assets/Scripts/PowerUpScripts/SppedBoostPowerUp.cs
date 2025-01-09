using System.Collections;
using UnityEngine;

public class SppedBoostPowerUp : PowerUp
{
    //[SerializeField] int timer = 2;

    PlayerController playerController;

    protected override void OnCollect(GameObject player, GameManager manager)
    {
        playerController = player.GetComponent<PlayerController>();
        playerController.Speed = 12.5f;
        Indicator indicatorScript = playerController.indicator.GetComponent<Indicator>();
        indicatorScript.ActivatePowerUp(this);
    }

    public override void DeactivateSelf()
    {
        Debug.Log("Deactivated Speed Boost");
        playerController.Speed = 10.0f;
    }
}
