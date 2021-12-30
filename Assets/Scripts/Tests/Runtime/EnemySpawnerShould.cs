using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpawnerShould
{
    private const string PATH_ENEMY_SPAWNER_PREFAB = "Assets/Prefabs/Enemy/EnemySpawner.prefab";

    [UnityTest]
    public IEnumerator CreateCorrectNumberOfEnemies()
    {
        GameObject enemySpawnerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_ENEMY_SPAWNER_PREFAB);
        GameObject enemySpawnerInstance = Object.Instantiate(enemySpawnerPrefab);
        EnemySpawner enemySpawner = enemySpawnerInstance.GetComponentInChildren<EnemySpawner>();

        yield return new WaitForEndOfFrame();

        int totalEnemiesExpected = enemySpawner.Rows * enemySpawner.Columns;
        int totalEnemiesSpawned = enemySpawner.TotalEnemiesCount;

        Assert.AreEqual(totalEnemiesExpected, totalEnemiesSpawned);
    }
}