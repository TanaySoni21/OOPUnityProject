using UnityEngine;

public class MissilesPowerUp : PowerUp
{
    [SerializeField] Projectile projectile;
    [SerializeField] float offSet = 1.5f;

    protected override void OnCollect(GameObject player, GameManager manager)
    {
        foreach (var enemy in manager.activeEnemies)
        {
            Vector3 enemyToPlayerNormal = (enemy.transform.position - player.transform.position).normalized;
            Vector3 projectileSpawnPos = player.transform.position + enemyToPlayerNormal * offSet;
            Quaternion projectileRotation = Quaternion.LookRotation(Vector3.up, enemyToPlayerNormal); 
            Projectile projectileInstance = Instantiate(projectile, projectileSpawnPos, projectileRotation);
            projectileInstance.SetTarget(enemy);
        }
    }
}
