using UnityEngine;

public class EnemyFactory
{
    private readonly EnemiesConfiguration enemiesConfiguration;

    public EnemyFactory(EnemiesConfiguration enemiesConfiguration)
    {
        this.enemiesConfiguration = enemiesConfiguration;
    }

    public GameObject Create(Vector2 objectPosition, Quaternion identity)
    {
        var enemyPrefab = enemiesConfiguration.GetEnemyPrefab();
        return Object.Instantiate(enemyPrefab, objectPosition, identity);
    }
}