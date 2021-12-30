using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerShould
{
    private const string PATH_PLAYER_PREFAB = "Assets/Prefabs/Player/Player.prefab";
    private const string PATH_ENEMY_PREFAB = "Assets/Prefabs/Enemy/Enemy.prefab";
    private const string PATH_ENEMY_PROJECTILE_PREFAB = "Assets/Prefabs/Projectile/EnemyProjectile.prefab";

    private GameObject playerPrefab;
    private GameObject playerInstance;
    private Vector3 playerInitialPosition = new Vector3(1, 1, 0);

    [SetUp]
    public void SetUp()
    {
        SetMainCamera();

        playerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_PLAYER_PREFAB);
        playerInstance = Object.Instantiate(playerPrefab, playerInitialPosition, Quaternion.identity);
    }

    [UnityTest]
    public IEnumerator DieWhenTriggerWithEnemy()
    {
        yield return new WaitForEndOfFrame();

        var enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_ENEMY_PREFAB);
        var enemyInstance = Object.Instantiate(enemyPrefab, playerInstance.transform.position, Quaternion.identity);

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(true, playerInstance.Equals(null));
    }

    [UnityTest]
    public IEnumerator DecrementHealthWhenReceiveDamage()
    {
        yield return new WaitForEndOfFrame();

        PlayerController player = playerInstance.GetComponent<PlayerController>();

        float initialPlayerHealth = player.Health;

        var projectilePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(PATH_ENEMY_PROJECTILE_PREFAB);
        var projectileInstance = Object.Instantiate(projectilePrefab, playerInstance.transform.position, Quaternion.identity);
        EnemyProjectile projectile = projectileInstance.GetComponent<EnemyProjectile>();

        yield return new WaitForEndOfFrame();

        float projectileDamage = projectile.damageAmount;
        float healthAfterDamage = initialPlayerHealth - projectileDamage;
                
        Assert.AreEqual(player.Health, healthAfterDamage);
    }

    private static void SetMainCamera()
    {
        //For Boundaries Orthographic class
        GameObject camera = new GameObject("Main Camera");
        camera.AddComponent(typeof(Camera));
        camera.tag = "MainCamera";
    }
}