using UnityEngine;

public class PushOutPowerUp : PowerUp
{
    [SerializeField] float pushOutForce;

    protected override void OnCollect(GameObject player, GameManager manager)
    {
        foreach (var enemy in manager.activeEnemies)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            Vector3 normal = (enemy.transform.position - player.transform.position).normalized;

            rb.AddForce(normal * pushOutForce, ForceMode.Impulse);
        }
    }
}
