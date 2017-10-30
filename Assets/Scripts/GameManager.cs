using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player; //object to track is Player
    float playerHeightY;
    //platforms
    public Transform regular;
    public Transform jump;
    public Transform leftRight;
    public Transform upDown;
    public Transform background;

    public int r;
    public int b;
    public int g;
    public int p;

    private int platNumber;

    private float platCheck;        //Checks of player height is near and spown platform
    private float backCheck;
    private float spawnPlatformsTo; //Previous location platforms were spawned from
    private float spawnBackTo;


    // Use this for initialization
    void Start ()
	{
        // Finds our game object using the Player tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
	{
        
	    playerHeightY = player.position.y;
        // If player height Y is greater than 0 then perform  PlatformManager method
        if (playerHeightY > platCheck)
	    {
	        PlatformManager();
	    }
        //Camera stuff
        float currentCameraHeight = transform.position.y;
	    float newHeightOfCamera = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime*10);

	    if (playerHeightY > currentCameraHeight)
	    {
	        transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);
	    }
	    else //restarting Scene
	    {
	        if (playerHeightY < currentCameraHeight - 6.25f)
	        {
                OnGUI2D.oG2D.SaveScore();
                Debug.Log(PlayerPrefs.GetInt("Score1"));
                OnGUI2D.oG2D.CheckHighScore();
	            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	        }
	    }

        // Score
	    if (playerHeightY > OnGUI2D.score)
	    {
	        OnGUI2D.score = (int)playerHeightY;
	    }

	}

    void LateUpdate()
    {
        backCheck = player.position.y + 15;
        backgroundSpawner(backCheck + 150);
    }

    void PlatformManager()
    {
        platCheck = player.position.y + 15;
        PlatformSpawner(platCheck + 15);
    }

    void PlatformSpawner(float floatValue)
    {
        float y = spawnPlatformsTo;
        while (y <= floatValue)
        {

            float x = Random.Range(-10.20f, 10.20f);
            platNumber = Random.Range(1, 5);
            Vector2 posXY = new Vector2(x, y);

            switch (platNumber)
            {
                case 1:
                    Instantiate(regular, posXY, Quaternion.identity);
                    g++;
                    PlayerPrefs.SetInt("g1", g);
                    break;
                case 2:
                    Instantiate(jump, posXY, Quaternion.identity);
                    r++;
                    PlayerPrefs.SetInt("r1", r);
                    break;
                case 3:
                    Instantiate(leftRight, posXY, Quaternion.identity);
                    b++;
                    PlayerPrefs.SetInt("b1", b);
                    break;
                case 4:
                    Instantiate(upDown, posXY, Quaternion.identity);
                    p++;
                    PlayerPrefs.SetInt("p1", p);
                    break;
            }

            y += Random.Range(0.7f, 1f); ; //Priveously was: Random.Range(2.5f, 3.5f);

            // Shows how many platforms are spawned at a time
           // Debug.Log("Spawned Platform");
        }
       spawnPlatformsTo = floatValue;
    }

    void backgroundSpawner(float floatValue)
    {
        float y = spawnBackTo + 50;
        while (y <= floatValue)
        {
            float x = 0f;
            //Vector2 posXY = new Vector2(x, y);
            Vector3 posXYZ = new Vector3(x, y, 100);
            Instantiate(background, posXYZ, Quaternion.identity);
            

           y += 80f; ; //Priveously was: Random.Range(2.5f, 3.5f);

            // Shows how many platforms are spawned at a time
            Debug.Log("Background");
        }
        spawnBackTo = floatValue;
        
    }

}
