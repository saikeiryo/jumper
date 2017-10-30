using UnityEngine;
using System.Collections;

public class Wrap2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (transform.position.x <= -10.4f)
	    {
	        transform.position = new Vector3(10.4f, transform.position.y, transform.position.z);
	    }

        else if (transform.position.x >= 10.4f)
        {
            transform.position = new Vector3(-10.4f, transform.position.y, transform.position.z);
        }
    }
}
