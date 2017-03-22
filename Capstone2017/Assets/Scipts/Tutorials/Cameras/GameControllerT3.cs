using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerT3 : MonoBehaviour
{
    #region Variables
    #region DefaultSystem Variables
    public GameObject ship;
    public bool paused = true;
    public Canvas pauseMenu;
    public ConsoleTextT3 consoleText;
    public AudioSource cameraSwitching;
    #endregion
    #region EngineSystem Variables
    public MoveShipT3 moveShip;
    //bool AIMoving;

    public Rigidbody spaceObject;
    public GameObject spawnObject;
    public Transform[] objectPoints;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab
    GameObject objectSpawnLocations;
    #endregion
    #region TurretSystem Variables
    GameObject shipSpawnLocations;
    public GameObject spawnShips;
    public Transform[] spawnpoints;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab
    public GameObject foeShip;
    public GameObject[] filledPoints;
    public Camera frontCamera, backCamera, interiorCamera;
    #endregion
    #region ShieldSystem Variables
    public GameObject shipIconFront, shipIconBack;
    public Sprite frontOfShip, backOfShip, frontDamaged, backDamaged, shieldDown1, shieldDown2;
    public int shieldLayers;
    public GameObject layersOfShield;
    public Sprite threeShieldLayers, thirdLayerDestroyed, twoShieldLayers, secondLayerDestroyed, oneShieldLayer, lastLayerDestroyed;
    public string cargoText;
    #endregion
    #endregion

void Start()
    {
        #region Ship Setup
        cargoText = "Good";
        Time.timeScale = 0;
        PauseGame(true);
        InvokeRepeating("CreateTheObject", 1.0f, 2.0f);
        InvokeRepeating("CreateTheShip", 5f, 4.0f);
        frontCamera.enabled = true;
        backCamera.enabled = false;
        interiorCamera.enabled = false;
        #endregion

        #region Spawn Setup
        objectPoints[0] = spawnObject.transform.Find("Left2Top");
        objectPoints[1] = spawnObject.transform.Find("Left2Middle");
        objectPoints[2] = spawnObject.transform.Find("Left2Bottom");
        objectPoints[3] = spawnObject.transform.Find("Left1Top");
        objectPoints[4] = spawnObject.transform.Find("Left1Middle");
        objectPoints[5] = spawnObject.transform.Find("Left1Bottom");
        objectPoints[6] = spawnObject.transform.Find("CenterTop");
        objectPoints[7] = spawnObject.transform.Find("CenterMiddle");
        objectPoints[8] = spawnObject.transform.Find("CenterBottom");
        objectPoints[9] = spawnObject.transform.Find("Right1Top");
        objectPoints[10] = spawnObject.transform.Find("Right1Middle");
        objectPoints[11] = spawnObject.transform.Find("Right1Bottom");
        objectPoints[12] = spawnObject.transform.Find("Right2Top");
        objectPoints[13] = spawnObject.transform.Find("Right2Middle");
        objectPoints[14] = spawnObject.transform.Find("Right2Bottom");

        spawnpoints[0] = spawnShips.transform.Find("Left2Top");
        spawnpoints[1] = spawnShips.transform.Find("Left2Middle");
        spawnpoints[2] = spawnShips.transform.Find("Left2Bottom");
        spawnpoints[3] = spawnShips.transform.Find("Left1Top");
        spawnpoints[4] = spawnShips.transform.Find("Left1Middle");
        spawnpoints[5] = spawnShips.transform.Find("Left1Bottom");
        spawnpoints[6] = spawnShips.transform.Find("CenterTop");
        spawnpoints[7] = spawnShips.transform.Find("CenterMiddle");
        spawnpoints[8] = spawnShips.transform.Find("CenterBottom");
        spawnpoints[9] = spawnShips.transform.Find("Right1Top");
        spawnpoints[10] = spawnShips.transform.Find("Right1Middle");
        spawnpoints[11] = spawnShips.transform.Find("Right1Bottom");
        spawnpoints[12] = spawnShips.transform.Find("Right2Top");
        spawnpoints[13] = spawnShips.transform.Find("Right2Middle");
        spawnpoints[14] = spawnShips.transform.Find("Right2Bottom");
        #endregion
    }

    #region The Pause Stuff
    public void PauseGame(bool changePauseTo)
    {
        paused = changePauseTo;
        if (paused == true)
        {
            pauseMenu.enabled = true;
        }
        else
        {
            pauseMenu.enabled = false;
        }
    }
    void Update()
    {
        if (paused == true && Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 1;
            PauseGame(false);
        }
        else if (paused == true && Input.GetKeyUp(KeyCode.Backspace))
        {
            GameOver();
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 0;
            PauseGame(true);
        }
        if (paused == false && Input.GetKeyUp(KeyCode.Alpha1))
        {
            cameraSwitching.Play();
            frontCamera.enabled = true;
            backCamera.enabled = false;
            interiorCamera.enabled = false;
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Alpha2))
        {
            cameraSwitching.Play();
            frontCamera.enabled = false;
            backCamera.enabled = true;
            interiorCamera.enabled = false;
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Alpha3))
        {
            cameraSwitching.Play();
            frontCamera.enabled = false;
            backCamera.enabled = false;
            interiorCamera.enabled = true;
        }
    }
    #endregion

    #region Spawn Things
    #region Object Spawning
    void CreateTheObject()
    {
        int randomSpawn = Random.Range(0, 15);
        Rigidbody newSpaceObject = Instantiate(spaceObject, objectPoints[randomSpawn].position, objectPoints[0].rotation) as Rigidbody;
        newSpaceObject.AddForce(transform.forward * -30, ForceMode.VelocityChange);
        int randomSpawn2 = CheckObjectSpawn(randomSpawn);
        Rigidbody newSpaceObject2 = Instantiate(spaceObject, objectPoints[randomSpawn2].position, objectPoints[0].rotation) as Rigidbody;
        newSpaceObject2.AddForce(transform.forward * -30, ForceMode.VelocityChange);
    }
    int CheckObjectSpawn(int previousSpawn)
    {
        int newSpawn = Random.Range(0, 15);
        while (newSpawn == previousSpawn)
        {
            newSpawn = Random.Range(0, 15);
        }
        return newSpawn;
    }
#endregion

    #region Ship Spawning
    void CreateTheShip()
    {
        int randomSpawn = Random.Range(0, 15);//min inclusive, max inclusive?
        if (filledPoints[randomSpawn] != null)
        {
            randomSpawn = CheckShipSpawn();
        }
        GameObject newFoeShip = Instantiate(foeShip, spawnpoints[randomSpawn].position, spawnpoints[randomSpawn].rotation) as GameObject;
        filledPoints[randomSpawn] = newFoeShip;
    }
    int CheckShipSpawn()
    {
        int minimumRandomRange = 0;
        int newSpawn = Random.Range(0, 15);
        while (filledPoints[newSpawn] != null)
        {
            newSpawn = Random.Range(minimumRandomRange, 15);
        }
        return newSpawn;
    }
    #endregion
    #endregion
    
    public void GotHit(bool front)
    {
        consoleText.DamageCargo();
        if (front == true)
        {
            StartCoroutine(DamageShip(true));
        }
        else
            StartCoroutine(DamageShip(false));
        float timer1 = 0; 
        timer1 += Time.deltaTime;
        if (timer1 > 1.0f)
        {
            timer1 = 0.0f;
        }

        if (shieldLayers >=1)
        {
            shieldLayers--;
            if (shieldLayers == 3)
            {
                layersOfShield.GetComponent<SpriteRenderer>().sprite = thirdLayerDestroyed;
                float timer2 = 0;
                timer2 += Time.deltaTime;
                if (timer2 > 1.0f)
                {
                    timer2 = 0.0f;
                }
                layersOfShield.GetComponent<SpriteRenderer>().sprite = twoShieldLayers;
            }
            else if (shieldLayers == 2)
            {
                layersOfShield.GetComponent<SpriteRenderer>().sprite = secondLayerDestroyed;
                float timer2 = 0;
                timer2 += Time.deltaTime;
                if (timer2 > 1.0f)
                {
                    timer2 = 0.0f;
                }
                layersOfShield.GetComponent<SpriteRenderer>().sprite = oneShieldLayer;
            }
            else
            {
                layersOfShield.GetComponent<SpriteRenderer>().sprite = lastLayerDestroyed;
                float timer2 = 0;
                timer2 += Time.deltaTime;
                if (timer2 > 1.0f)
                {
                    timer2 = 0.0f;
                }
                layersOfShield.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        else
        {
            
            ShieldUp(false);
            if (PlayerPrefs.GetInt("cargoText") == 3)
            {
                cargoText = "Fair";
                PlayerPrefs.SetInt("cargoText", 2);
            }
            else if (PlayerPrefs.GetInt("cargoText") == 2)
            {
                cargoText = "Poor";
                PlayerPrefs.SetInt("cargoText", 1);
            }
            else if (PlayerPrefs.GetInt("cargoText") == 1)
            {
                PlayerPrefs.SetInt("cargoText", 0);
                GameOver();
            }
            else
            {
                Debug.Log("error in DamageCargo");
            }
        }
    }
    IEnumerator DamageShip(bool front)
    {
        if (front == true)
        {
            shipIconFront.GetComponent<SpriteRenderer>().sprite = frontDamaged;
        }
        else
            shipIconBack.GetComponent<SpriteRenderer>().sprite = backDamaged;
        float counter = 0f;
        float length = .1f;
        while (counter <= length)
        {//keeps the loop going until real time has met the desired length
            counter += Time.deltaTime;
            yield return null;
        }
        if (front == true)
        {
            shipIconFront.GetComponent<SpriteRenderer>().sprite = frontOfShip;
            //Checks Shield Level
        }
        else
            shipIconBack.GetComponent<SpriteRenderer>().sprite = backOfShip;
    }
    public void ShieldUp(bool shield)
    {
        if (shield == true)
        {
            shipIconFront.GetComponent<SpriteRenderer>().sprite = frontOfShip;
            shipIconBack.GetComponent<SpriteRenderer>().sprite = backOfShip;
            layersOfShield.GetComponent<SpriteRenderer>().sprite = threeShieldLayers;
            shieldLayers = 3;
        }
        else
        {
            shipIconFront.GetComponent<SpriteRenderer>().sprite = frontDamaged;
            shipIconBack.GetComponent<SpriteRenderer>().sprite = backDamaged;
        }
    }

    public void GameOver()
    {Debug.Log("Got called?");
        SceneManager.LoadScene("MenuSystem");
    }
}