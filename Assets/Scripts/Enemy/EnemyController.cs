using Scripts.Events;
using SuperMaxim.Messaging;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyData))]
public class EnemyController : MonoBehaviour
{        
    public EnemyData enemyData;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private HealthbarEnemy healthbar;

    private float health;
    private int score;
    private float fireInterval;
    private ConsoleColor color;

    public float Health { get => health; set => health = value; }
    public int Score { get => score; set => score = value; }
    public float FireInterval { get => fireInterval; set => fireInterval = value; }
    public ConsoleColor Color { get => color; set => color = value; }

    private IFireable projectile;

    private void Awake()
    {
        projectile = GetComponent<IFireable>();
        StartCoroutine(Fire());

        InitData();
        SetColor();
    }

    public void InitData()
    {
        Health = enemyData.health;
        Score = enemyData.score;
        FireInterval = enemyData.fireInterval;
        Color = enemyData.color;        
    }

    public void SetColor()
    {
        string colorString = Color.ToString();
        sprite.color = ColorUtility.TryParseHtmlString(colorString, out Color unityColor) ? unityColor : sprite.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(collision);
        Destroy(collision.gameObject);
    }

    private void TakeDamage(Collider2D collision)
    {
        PlayerProjectile projectile = collision.GetComponent<PlayerProjectile>();
        if (projectile != null)
        {
            Health -= projectile.damageAmount;            
            healthbar?.UpdateHealthbar(Health);
            if (Health <= 0)
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        Messenger.Default.Publish(new EnemyDestroyEvent(this));        
        AudioSource.PlayClipAtPoint(enemyData.onDieClip, gameObject.transform.position);
        Destroy(gameObject);
    }

    private IEnumerator Fire()
    {
        if (projectile != null)
        {
            while (true)
            {
                yield return new WaitForSeconds(FireInterval);
                projectile.Fire();
            }
        }
    }
}