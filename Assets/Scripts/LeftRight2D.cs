using UnityEngine;
using System.Collections;

public class LeftRight2D : MonoBehaviour
{

    float platformSpeed = 3f;
    bool endPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (endPoint)
	    {
	        transform.position += Vector3.right * platformSpeed * Time.deltaTime;
	    }
	    else
	    {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

	    if (transform.position.x >= 4.15f )
	    {
	        endPoint = false;
	    }
        if (transform.position.x <= -4.15f)
        {
            endPoint = true;
        }
    }
}
