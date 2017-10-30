using UnityEngine;
using System.Collections;

public class Jump2D : MonoBehaviour
{

    public bool grounded;
    public float jumpHeight = 400f;
    public Transform groundCheck;
    public Rigidbody2D rb;

    public float groundRadius = 0.2f;
    public LayerMask ground;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        float velY = rb.velocity.y;
	    grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);

	    if (grounded && velY<=0)
	    {
	        

	            //float v = Input.GetAxis("Vertical");
	            rb.velocity = new Vector2(0, 0);
	            rb.AddForce(new Vector2(0,  jumpHeight));
	            //rb.AddForce(new Vector2(0, v * 10), ForceMode2D.Impulse);
	        
	    }
	}
}
