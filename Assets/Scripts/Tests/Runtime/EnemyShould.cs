using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyShould
{
    private const string PATH_PLAYER_PROJECTILE_PREFAB = "Assets/Prefabs/Projectile/PlayerProjectile.prefab";
    private const string PATH_ENEMY_PREFAB = "Assets/Prefabs/Enemy/Enemy.prefab";

    private Vector3 enemyInitialPosition = new Vector3(1, 1, 0);

    [UnityTest]
    public IEnumerator DecrementHealthWhenReceiveDamage()
    {
        GameObject enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_ENEMY_PREFAB);
        GameObject enemyInstance = Object.Instantiate(enemyPrefab, enemyInitialPosition, Quaternion.identity);
        EnemyController enemy = enemyInstance.GetComponent<EnemyController>();
        yield return new WaitForEndOfFrame();

        enemy.InitData();

        float initialEnemyHealth = enemy.Health;

        var projectilePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_PLAYER_PROJECTILE_PREFAB);
        var projectileInstance = Object.Instantiate(projectilePrefab, enemyInstance.transform.position, Quaternion.identity);

        PlayerProjectile projectile = projectileInstance.GetComponent<PlayerProjectile>();

        yield return new WaitForEndOfFrame();

        float projectileDamage = projectile.damageAmount;
        float healthAfterDamage = initialEnemyHealth - projectileDamage;

        Assert.AreEqual(enemy.Health, healthAfterDamage);
    }
}