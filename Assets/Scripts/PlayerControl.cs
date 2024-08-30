using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform onGroundCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool onGround;
    private float horizontal;
    public float speed;
    public float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(onGroundCheck.position, 0.2f, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) && onGround || Input.GetKeyDown(KeyCode.Space) && onGround || Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
