using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerT1 : MonoBehaviour
{
    #region EngineSystem Variables
    public GameObject ship;
    float shipMovementSpeed;
    public MoveShip moveShip;

    public bool paused = true;
    public Canvas pauseMenu;

    public ConsoleText consoleText;

    bool AIMoving;
    
    public Transform[] spawnpoints;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab
    public Rigidbody spaceObject;
    float objectMovementSpeed = -20.0f;
    #endregion

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 0;
        PauseGame(true);
        #region EngineSystem Setup
        shipMovementSpeed = 3;
        moveShip.movementSpeed = shipMovementSpeed;
        InvokeRepeating("CreateTheObject", 1.0f, .5f);
        #endregion
    }

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

    // Update is called once per frame
    void Update ()
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
    }

    void CreateTheObject()
    {//Spawns a ship randomly within the CubeMatrix for the Engine System
        int randomSpawn = Random.Range(0, 15); //This randomizes the spawnpoint
        int randomSpawn2 = CheckTheSpawn(randomSpawn);
        Rigidbody newSpaceObject = Instantiate(spaceObject, spawnpoints[randomSpawn].position, spawnpoints[0].rotation) as Rigidbody;
        newSpaceObject.AddForce(transform.forward * objectMovementSpeed, ForceMode.VelocityChange);
        Rigidbody newSpaceObject2 = Instantiate(spaceObject, spawnpoints[randomSpawn2].position, spawnpoints[0].rotation) as Rigidbody;
        newSpaceObject2.AddForce(transform.forward * objectMovementSpeed, ForceMode.VelocityChange);
    }

    int CheckTheSpawn(int previousSpawn)
    {
        int newSpawn = Random.Range(0, 15);
        while (newSpawn == previousSpawn)
        {
            Debug.Log("P= "+previousSpawn+"\nN= "+newSpawn);
            newSpawn = Random.Range(0, 15);
            Debug.Log("NewSpawn= " + newSpawn);
        }
        Debug.Log("PreviousSpawn= " + previousSpawn + "\nNewSpawn= " + newSpawn);
        return newSpawn;
    }

    public void GotHit()
    {
        //Checks Shield Level
        consoleText.DamageCargo();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
