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
    #endregion

    #region EngineSystem Variables
    public MoveShipT3 moveShip;
    bool AIMoving;

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

    public AudioSource cameraSwitching;
    #endregion
    #endregion

    void Start()
    {
        #region Ship Setup
        Time.timeScale = 0;
        PauseGame(true);
        InvokeRepeating("CreateTheObject", 1.0f, 2.0f);
        InvokeRepeating("CreateTheShip", 2f, 2.0f);
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
    
    public void GotHit()
    {
        Debug.Log("GotHit");
        //Checks Shield Level
        consoleText.DamageCargo();
    }

    public void GameOver()
    {Debug.Log("Got called?");
        Application.Quit();
    }
}