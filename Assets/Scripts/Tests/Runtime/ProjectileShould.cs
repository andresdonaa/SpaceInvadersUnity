using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class ProjectileShould
{
    private const string PATH_ENEMY_PROJECTILE_PREFAB = "Assets/Prefabs/Projectile/EnemyProjectile.prefab";
    private const string PATH_PLAYER_PROJECTILE_PREFAB = "Assets/Prefabs/Projectile/PlayerProjectile.prefab";

    private Vector3 projectileInitialPosition = new Vector3(1, 1, 0);

    [UnityTest]
    public IEnumerator DestroyItselfWhenCollidesWithOtherTypeOfProjectile()
    {
        GameObject playerProjectilePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_PLAYER_PROJECTILE_PREFAB);
        GameObject playerProjectileInstance = Object.Instantiate(playerProjectilePrefab, projectileInitialPosition, Quaternion.identity);
        yield return new WaitForEndOfFrame();

        GameObject enemyProjectilePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_ENEMY_PROJECTILE_PREFAB);
        GameObject enemyProjectileInstance = Object.Instantiate(enemyProjectilePrefab, projectileInitialPosition, Quaternion.identity);
        yield return new WaitForEndOfFrame();

        Assert.AreEqual(true, playerProjectileInstance.Equals(null));
        Assert.AreEqual(true, enemyProjectileInstance.Equals(null));
    }
}