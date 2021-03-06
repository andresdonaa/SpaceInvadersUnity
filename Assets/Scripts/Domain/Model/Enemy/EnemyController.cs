using Scripts.Events;
using SuperMaxim.Messaging;
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyDataSO))]
public class EnemyController : MonoBehaviour
{
    public EnemyDataSO enemyData;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Sprite dieSprite;
    [SerializeField] private HealthbarEnemyView healthbar;

    private float health;
    private int score;
    private ConsoleColor color;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;
    private Animator animator;

    public float Health { get => health; set => health = value; }
    public int Score { get => score; set => score = value; }
    public ConsoleColor Color { get => color; set => color = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (healthbar)
            healthbar.SetMaxHealth(enemyData.health);
    }

    public void InitData()
    {
        Health = enemyData.health;
        Score = enemyData.score;
        Color = enemyData.color;

        EnemyFire enemyFire = GetComponent<EnemyFire>();
        if (enemyFire != null && !enemyFire.Equals(null))
            enemyFire.FireInterval = enemyData.fireInterval;
    }

    public void SetColor()
    {
        string colorString = Color.ToString();
        sprite.color = ColorUtility.TryParseHtmlString(colorString, out Color unityColor) ? unityColor : sprite.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerProjectile projectile = collision.GetComponent<PlayerProjectile>();
        if (projectile != null)
        {
            TakeDamage(projectile.damageAmount);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        healthbar?.UpdateHealthbar(Health);
        if (Health <= 0)
        {            
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(enemyData.onDieClip, gameObject.transform.position);
        spriteRenderer.sprite = dieSprite;
        healthbar.gameObject.SetActive(false);
        animator.enabled = false;
        collider.enabled = false;
        transform.parent = null;
        Destroy(gameObject, 0.5f);
    }

    private void OnDestroy()
    {
        Messenger.Default.Publish(new EnemyDestroyEvent(this));
    }
}