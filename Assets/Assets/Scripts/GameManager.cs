using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies;
    [SerializeField] List<PowerUp> powerUps;
    [SerializeField] int level = 1;

    public bool isGameOver = false;

    public Enemy[] activeEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            activeEnemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            if (activeEnemies.Length == 0)
            {
                level++;
                SpawnEnemies();
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0;i<level;i++)
        {
            Vector3 randomSpawnPosEnemy = new Vector3 (Random.Range(-9, 9), 2, Random.Range(-9, 9));
            Enemy enemy = enemies[enemyIndex()];
            Instantiate(enemy, randomSpawnPosEnemy, enemy.transform.rotation);
        }

        Vector3 randomSpawnPos = new Vector3(Random.Range(-9, 9), 0.2f, Random.Range(-9, 9));
        PowerUp powerUp = powerUps[Random.Range(0, powerUps.Count)];
        Instantiate(powerUp, randomSpawnPos, powerUp.transform.rotation);
    }

    int enemyIndex()
    {
        int index = 0;
        List<Enemy> levelEnemies = new List<Enemy>();

        foreach (var enemy in enemies)
        {
            if (2 * enemy.Level <= level)
            {
                levelEnemies.Add(enemy);
            }
        }

        index = Random.Range(0, levelEnemies.Count);
        return index;
    }

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(2);
    }
}
