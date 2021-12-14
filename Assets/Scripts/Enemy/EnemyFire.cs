using Scripts.Events;
using SuperMaxim.Messaging;
using System;
using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private IFireable projectile;
    private float fireInterval;
    private bool canShoot = true;

    public float FireInterval { get => fireInterval; set => fireInterval = value; }

    private void Awake()
    {
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOverEvent);

        projectile = GetComponent<IFireable>();
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

    private IEnumerator Fire()
    {
        if (projectile != null)
        {
            while (canShoot)
            {
                yield return new WaitForSeconds(FireInterval);
                projectile.Fire();
            }
        }
    }
}