using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies;
    [SerializeField] List<PowerUp> powerUps;
    [SerializeField] int level = 1;

    public Enemy[] activeEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        if(activeEnemies.Length == 0)
        {
            level++;
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0;i<level;i++)
        {
            Vector3 randomSpawnPosEnemy = new Vector3 (Random.Range(-9, 9), 2, Random.Range(-9, 9));
            Enemy enemy = enemies[Random.Range(0, enemies.Count)];
            Instantiate(enemy, randomSpawnPosEnemy, enemy.transform.rotation);
        }

        Vector3 randomSpawnPos = new Vector3(Random.Range(-9, 9), 0.2f, Random.Range(-9, 9));
        PowerUp powerUp = powerUps[Random.Range(0, powerUps.Count)];
        Instantiate(powerUp, randomSpawnPos, powerUp.transform.rotation);
    }
}
