using UnityEngine;
using System.Collections;

//this script goes to Player

public class JumpPlat2D : MonoBehaviour
{
    public float jumpHeight = 500f;
    Rigidbody2D rb;
    float velY;
    public LayerMask ground;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    bool grounded;

    // Use this for initialization
    void Start ()
    {
         rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    velY = rb.velocity.y;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (grounded && other.tag == "JumpPlat" && velY<=0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpHeight));
        }
    }
}
