using Scripts.Events;
using SuperMaxim.Messaging;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerData))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private float health;

    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    public float Health { get => health; set => health = value; }

    private void Awake()
    {
        Messenger.Default.Subscribe<GameOverEvent>(OnGameOver);

        InitData();

        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<GameOverEvent>(OnGameOver);
    }

    private void InitData()
    {
        health = playerData.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Messenger.Default.Publish(new GameOverEvent());
            return;
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
}