using Scripts.Events;
using SuperMaxim.Messaging;
using System.Collections;
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
        
        InitData();

        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        projectile = GetComponent<IFireable>();
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<FireButtonPressedEvent>(Fire);
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
        TakeDamage(collision);
        Destroy(collision.gameObject);
    }   

    private void TakeDamage(Collider2D collision)
    {
        EnemyProjectile projectile = collision.GetComponent<EnemyProjectile>();
        if (projectile != null)
        {            
            health -= projectile.damageAmount;
            Messenger.Default.Publish(new PlayerTakeDamageEvent(this));            
            
            if (health <= 0)
            {
                Messenger.Default.Publish(new PlayerDieEvent());                
                
                AudioSource.PlayClipAtPoint(playerData.onDieClip, gameObject.transform.position);
                
                Die();                
            }            
        }
    }

    private void Die()
    {
        InitData();
        StartCoroutine(Blink.BlinkWithDisableColliderCoroutine(collider, spriteRenderer));
        Respawn();
    }    

    private void Respawn()
    {
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

public static class Blink
{
    public static IEnumerator BlinkWithDisableColliderCoroutine(BoxCollider2D collider, SpriteRenderer spriteRenderer)
    {
        collider.enabled = false;

        for (int i = 0; i < 15; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
}