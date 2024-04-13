using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    float speed;
    float move;

    float jump;
    bool isJumping;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 400f;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce (new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
