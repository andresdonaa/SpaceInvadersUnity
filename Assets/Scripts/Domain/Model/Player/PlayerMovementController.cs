using Scripts.Services;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerDataSO playerData;

    private float speed;
    private IInput input;
    private Vector2 movement;

    private void Awake()
    {
        input = new PlayerInputController();
        InitData();
    }

    private void Update()
    {
        input.Tick();
    }

    private void FixedUpdate()
    {
        Movement(input.Horizontal, speed);
    }

    private void InitData()
    {
        speed = playerData.speed;     
    }

    private void Movement(float horizontal, float speed)
    {
        movement = new Vector2(horizontal, 0.0f);

        if (rigidBody != null && !rigidBody.Equals(null))
        {
            rigidBody.velocity = movement * speed;
            rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y);
        }        
    }    
}