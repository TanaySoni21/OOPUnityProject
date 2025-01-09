using UnityEngine;

public class StrengthPowerUp : PowerUp
{
    PlayerController playerController;

    protected override void OnCollect(GameObject player, GameManager manager)
    {
        playerController = player.GetComponent<PlayerController>();
        playerController.hasStrengthPowerUp = true;
        Indicator indicator = playerController.indicator.GetComponent<Indicator>();
        indicator.ActivatePowerUp(this);
    }

    public override void DeactivateSelf()
    {
        playerController.hasStrengthPowerUp = false;
        Debug.Log("Strength powerup deactivated");
    }
}
