using Scripts.Services;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerDataSO playerData;

    private float speed;
    private IShipInput shipInput;
    private Vector2 movement;

    private void Awake()
    {
        shipInput = new PlayerInputController();
        InitData();
    }

    private void Update()
    {
        shipInput.Tick();
    }

    private void FixedUpdate()
    {
        DoMovement(shipInput.Horizontal, speed);
    }

    private void InitData()
    {
        speed = playerData.speed;     
    }

    private void DoMovement(float horizontal, float speed)
    {
        movement = new Vector2(horizontal, 0.0f);

        if (rigidBody != null && !rigidBody.Equals(null))
        {
            rigidBody.velocity = movement * speed;
            rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y);
        }        
    }    
}