using UnityEngine;
using System.Collections;
using UnityEngine.Internal;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
	{
	    float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);  
	}
}
