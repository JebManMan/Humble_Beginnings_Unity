using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Move : MonoBehaviour
{


    Player_Controls controls;
    public float player_move_speed = 5;
    public Rigidbody2D player_rb;
    Vector2 move;
    Vector2 mouse_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new Player_Controls();
        // Callback to link function
        controls.Normal_Gameplay.MainAttack.performed += ctx => Player_Attack();
        controls.Normal_Gameplay.PlayerRotate.performed += ctx => mouse_pos = ctx.ReadValue<Vector2>();
        controls.Normal_Gameplay.PlayerMovement.performed += ctx => move = ctx.ReadValue<Vector2>(); 
        controls.Normal_Gameplay.PlayerMovement.canceled += ctx => move = ctx.ReadValue<Vector2>();
    } 

    // Update is called once per frame
    void Update()
    {
        controls.Normal_Gameplay.Enable();
        Vector2 movement_amount = new Vector2(move.x, move.y) * player_move_speed;
        player_rb.linearVelocity = movement_amount;
        //transform.Translate(movement_amount, Space.World);

        // Making player point at the camera 
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;

        Vector2 direction = mouseWorldPos - transform.position;
        transform.up = direction;

        //controls.Normal_Gameplay.Throw.performed += ctx.ReadValue<Vector2>() => Throw(); 
        //controls.Normal_Gameplay.canceled += ctx => throw_vector = Vector.zero;
    }

    void Player_Attack()
    {
        Debug.Log("ATTACKING");
        // Calls Shoot from PLayer_Shoot script
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gameObject.GetComponent<Player_Shoot>().Shoot(mouseWorldPos);
    }
}
