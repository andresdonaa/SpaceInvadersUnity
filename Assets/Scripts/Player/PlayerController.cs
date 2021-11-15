using Scripts.Events;
using SuperMaxim.Messaging;
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerData))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerData playerData;

    private float speed;
    private float health;
    private InputController input;
    private Vector2 movement;
    private IFireable projectile;

    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    public float Health { get => health; set => health = value; }

    private void Awake()
    {
        input = new InputController();
        Messenger.Default.Subscribe<FireButtonPressedEvent>(Fire);
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOver);

        InitData();

        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        projectile = GetComponent<IFireable>();
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<FireButtonPressedEvent>(Fire);
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOver);
    }

    private void InitData()
    {
        speed = playerData.speed;
        health = playerData.health;
    }

    private void Update()
    {
        input.Tick();
    }

    private void FixedUpdate()
    {
        Movement(input.Horizontal, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (enemy != null)
        {   
            Messenger.Default.Publish(new PlayerCollisionWithEnemyEvent());
        }

        EnemyProjectile projectile = collision.GetComponent<EnemyProjectile>();
        if (projectile != null)
        {
            TakeDamage(projectile.damageAmount);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Messenger.Default.Publish(new PlayerTakeDamageEvent(this));

        if (health <= 0)
        {
            Messenger.Default.Publish(new PlayerDieEvent());

            AudioSource.PlayClipAtPoint(playerData.onDieClip, gameObject.transform.position);

            Die();
        }
    }

    private void Die()
    {
        InitData();
        StartCoroutine(Blink.BlinkCoroutine(collider, spriteRenderer));
        Respawn();
    }

    private void OnGameOver(GameOverEvent gameOverEvent)
    {
        Destroy(gameObject);
    }

    private void Respawn()
    {
        Debug.Log("Respawn Player...");
        Messenger.Default.Publish(new PlayerRespawnEvent(this));
    }

    private void Movement(float horizontal, float speed)
    {
        movement = new Vector2(horizontal, 0.0f);
        rigidBody.velocity = movement * speed;
        rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y);
    }

    private void Fire(FireButtonPressedEvent fireButtonPressedEvent)
    {
        if (projectile != null)
        {
            projectile.Fire();
        }
    }
}