using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSpawn : MonoBehaviour {

    public Transform player;
    public Transform background;
    private float backCheck;
    private float spawnBackTo;
    float playerHeightY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerHeightY = player.position.y;

    }

    void PlatformManager()
    {
        backCheck = player.position.y + 1;
        backgroundSpawner(backCheck + 1);
    }

    void backgroundSpawner(float floatValue)
    {
        float y = spawnBackTo;
        while (y <= floatValue)
        {
            float x = 0f;
            Vector2 posXY = new Vector2(x, y);

            Instantiate(background, posXY, Quaternion.identity);


            y += 10f; ; //Priveously was: Random.Range(2.5f, 3.5f);

            // Shows how many platforms are spawned at a time
            Debug.Log("Background Platform");
        }
        spawnBackTo = floatValue;
    }
}
