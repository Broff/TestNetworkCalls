using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {
    
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpSpeed;

    private bool isGround = false;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    void Start()
    {
        if (isLocalPlayer)
        {
            body = GetComponent<Rigidbody2D>();
            sprite = GetComponentInChildren<SpriteRenderer>();
            sprite.color = Color.blue;
        }
    }

	void Update () {
        
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            Jump();
        }        
	}

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //if (isLocalPlayer)
        {
            IsGround();
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * moveSpeed);
        sprite.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        if (isGround)
        {
            body.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            isGround = false;   
        }
    }

    private void IsGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        isGround = colliders.Length > 1;
    }
}
