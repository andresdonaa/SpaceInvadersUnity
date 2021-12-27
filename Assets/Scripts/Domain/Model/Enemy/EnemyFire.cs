using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private IFireable projectile;
    private float fireInterval;
    private bool canShoot = true;
    private Transform projectileSpawnPoint;

    public float FireInterval { get => fireInterval; set => fireInterval = value; }

    private void Awake()
    {
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOverEvent);

        projectile = GetComponent<IFireable>();
        projectileSpawnPoint = projectile.SpawnPoint;

        StartCoroutine(Fire());
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOverEvent);
    }

    private void OnGameOverEvent(GameOverEvent gameOverEvent)
    {
        canShoot = false;
    }

    private bool IsThereAnotherEnemyBelow()
    {
        return RaycastService.IsThereAnotherObjectOfTypeInDirection<EnemyController>(projectileSpawnPoint, Vector2.down);
    }

    private IEnumerator Fire()
    {
        if (projectile != null)
        {
            while (canShoot)
            {
                yield return new WaitForSeconds(FireInterval);

                if (!IsThereAnotherEnemyBelow())
                    projectile.Fire();
            }
        }
    }
}