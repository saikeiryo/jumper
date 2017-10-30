using UnityEngine;
using System.Collections;

public class UpDown2D : MonoBehaviour {

    float platformSpeed = 1.5f;
    bool endPoint;
    float endPointY;
    float startPoint;
    public int unitsToMove = 2;

    // Use this for initialization
    void Start ()
    {
        startPoint = transform.position.y;
        endPointY = startPoint + unitsToMove;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (endPoint)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }

        if (transform.position.y >= endPointY)
        {
            endPoint = false;
        }
        if (transform.position.y <= startPoint)
        {
            endPoint = true;
        }
    }
}
