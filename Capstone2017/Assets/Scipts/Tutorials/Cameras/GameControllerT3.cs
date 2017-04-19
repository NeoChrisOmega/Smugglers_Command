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
    public MeshRenderer focusedCamera, leftCamera, rightCamera;
    public int focusedCameraNum;
    public Material frontScreen, backScreen, interiorScreen;
    #endregion
    #region ShieldSystem Variables
    //public GameObject shipIconFront, shipIconBack;
    //public Sprite frontOfShip, backOfShip, frontDamaged, backDamaged, shieldDown1, shieldDown2;
    public int shieldLayers;
    public GameObject shipShield;
    public Sprite threeShieldLayers, thirdLayerDestroyed, twoShieldLayers, secondLayerDestroyed, oneShieldLayer, lastLayerDestroyed, shipExposed, shipDamaged;
    public GameObject cargoCond1, cargoCond2, cargoCond3;
    public string lightSpeedText;
    #endregion
    #endregion

void Start()
    {
        #region Ship Setup
        shieldLayers = 3;
        PlayerPrefs.SetInt("cargoText", 3);
        Time.timeScale = 0;
        PauseGame(true);
        InvokeRepeating("CreateTheObject", 1.0f, 2.0f);
        InvokeRepeating("CreateTheShip", 5f, 4.0f);
        focusedCamera.material = frontScreen;
        leftCamera.material = backScreen;
        rightCamera.material = interiorScreen;
        focusedCameraNum = 1;
        cargoCond1.SetActive(true);
        cargoCond2.SetActive(true);
        cargoCond3.SetActive(true);
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
        Debug.Log(shieldLayers);
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
            focusedCamera.material = frontScreen;
            leftCamera.material = backScreen;
            rightCamera.material = interiorScreen;
            focusedCameraNum = 1;
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Alpha2))
        {
            cameraSwitching.Play();
            focusedCamera.material = backScreen;
            leftCamera.material = frontScreen;
            rightCamera.material = interiorScreen;
            focusedCameraNum = 2;
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Alpha3))
        {
            cameraSwitching.Play();
            focusedCamera.material = interiorScreen;
            leftCamera.material = frontScreen;
            rightCamera.material = backScreen;
            focusedCameraNum = 3;
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
    
    public IEnumerator GotHit(bool front)
    {
        if (shieldLayers >=1)
        {
            Debug.Log("Within shield check");
            if (shieldLayers == 3)
            {
                Debug.Log("shieldLayer = 3");
                shipShield.GetComponent<SpriteRenderer>().sprite = thirdLayerDestroyed;
                yield return null;
                shipShield.GetComponent<SpriteRenderer>().sprite = twoShieldLayers;
                yield return null;
            }
            else if (shieldLayers == 2)
            {
                Debug.Log("shieldLayer = 2");
                shipShield.GetComponent<SpriteRenderer>().sprite = secondLayerDestroyed;
                yield return null;
                shipShield.GetComponent<SpriteRenderer>().sprite = oneShieldLayer;
                yield return null;
            }
            else
            {
                Debug.Log("shieldLayer = 1");
                shipShield.GetComponent<SpriteRenderer>().sprite = lastLayerDestroyed;
                yield return null;
                shipShield.GetComponent<SpriteRenderer>().sprite = shipExposed;
                yield return null;
            }
            shieldLayers--;
        }
        else
        {
            Debug.Log("Why?");
            ShieldUp(false);
            if (PlayerPrefs.GetInt("cargoText") == 3)
            {
                cargoCond1.SetActive(false);
                cargoCond2.SetActive(true);
                cargoCond3.SetActive(true);
                yield return null;
                PlayerPrefs.SetInt("cargoText", 2);
            }
            else if (PlayerPrefs.GetInt("cargoText") == 2)
            {
                cargoCond1.SetActive(false);
                cargoCond2.SetActive(false);
                cargoCond3.SetActive(true);
                yield return null;
                PlayerPrefs.SetInt("cargoText", 1);
            }
            else
            {
                cargoCond1.SetActive(false);
                cargoCond2.SetActive(false);
                cargoCond3.SetActive(false);
                yield return null;
                PlayerPrefs.SetInt("cargoText", 0);
                GameOver();
            }
            shipShield.GetComponent<SpriteRenderer>().sprite = shipDamaged;
            yield return null;
            yield return null;
            shipShield.GetComponent<SpriteRenderer>().sprite = shipExposed;
            yield return null;
        }
    }
    public void ShieldUp(bool shield)
    {
        if (shield == true)
        {
            //shipIconFront.GetComponent<SpriteRenderer>().sprite = frontOfShip;
            //shipIconBack.GetComponent<SpriteRenderer>().sprite = backOfShip;
            shipShield.GetComponent<SpriteRenderer>().sprite = threeShieldLayers;
            shieldLayers = 3;
        }
        else
        {
            //shipIconFront.GetComponent<SpriteRenderer>().sprite = frontDamaged;
            //shipIconBack.GetComponent<SpriteRenderer>().sprite = backDamaged;
        }
    }
    public void GameOver()
    {Debug.Log("Got called?");
        SceneManager.LoadScene("MenuSystem");
    }
}