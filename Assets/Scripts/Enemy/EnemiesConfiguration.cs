using System.Collections.Generic;
using UnityEngine;

public class EnemiesConfiguration : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemyData[] enemyTypes;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public void SetVariants(List<EnemyController> spawnedEnemies)
    {
        foreach (EnemyController enemy in spawnedEnemies)
        {
            enemy.enemyData = enemyTypes[Random.Range(0, enemyTypes.Length)];
            enemy.InitData();
            enemy.SetColor();
        }
    }
}