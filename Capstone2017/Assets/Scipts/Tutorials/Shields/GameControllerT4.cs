using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerT4 : MonoBehaviour
{
    #region Comment Keys

    //-PausedStuff-
    /*
    This is everything that happens when the game is paused,
    or things that can pause the game
    */

    //-ConsoleStuff-
    /*
    This is for anything that will appear at the bottom where the console is,
    anything that it represents, or effected by
    */

    //-CameraStuff-
    /*
    This is anything that changes or is effected by which camera is shown
    */

    //-AudioStuff-
    /*
    Anything that is, plays, or needs audio
    */

    //-ObjectInteraction-
    /*
    This will involve anything and everything that the game world can
    interact with itself. For example the objects hitting the ship,
    or the ship shooting a bullet, or spawnpoints
    */

    //-GameInteraction-
    /*
    Anything that can change more than just the stuff within this one level.
    For example, entering or exiting a level, variables that are needed outside
    this particular level, and other things like that
    */
    #endregion

    #region CameController Variables
    //-ObjectInteraction-
    public Rigidbody spaceObject;
    float objectMovementSpeed = -20.0f;
    public Transform spawnpoint;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab

    //-GameInteraction-
    public FixShieldT4 shieldController;
    public int shieldCond; //3 is best 0 is destroyed
    public MoveShipShield shipController;
    public string cargoCond; //3 is best 0 is destroyed

    //-ConsoleStuff-
    public ConsoleTextShield consoleText;
    //-ObjectInteraction-
    bool stopSpawning = false; //This is just a test to see if Shield works

    //-PausedStuff-
    public bool paused = true;
    public Canvas pauseMenu;

    //-CameraStuff-
    public Camera frontCamera, interiorCamera;

    //-AudioStuff-
    public AudioSource cameraSwitching;
    #endregion
    
    void Start ()
    {
        #region Default Setup
        //-PausedStuff-
        Time.timeScale = 0;
        PauseGame(true);

        //-CameraStuff-
        frontCamera.enabled = true;
        interiorCamera.enabled = false;
        
        //-ConsoleStuff-
        cargoCond = "Good";
        shieldCond = 3;
        #endregion

        #region EngineSystem Setup
        //-ObjectInteraction-
        InvokeRepeating("CreateTheObject", 1.0f, .5f);
        #endregion
    }

    public void PauseGame(bool changePauseTo)
    {
        //-PausedStuff-
        paused = changePauseTo;
        if (paused == true)
        {
            pauseMenu.enabled = true;
            //-AudioStuff-
            //Maybe I should not only have a sound for pausing and unpausing, but also a way to stop other sounds from playing
        }
        else
        {
            pauseMenu.enabled = false;
            //-AudioStuff-
            //This will make it so that I don't have to keep track of where the code can pause the game, instead I just do it within this method
        }
    }
    
    void Update ()
    {
        //-ConsoleStuff-
        if (shieldCond == 0 && cargoCond != "Good")
        {
            //-ObjectInteraction-
            stopSpawning = true;
        }
        else
            //-ObjectInteraction-
            stopSpawning = false;

        //-PausedStuff-
        if (paused == true && Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 1;
            PauseGame(false);
        }
        else if (paused == true && Input.GetKeyUp(KeyCode.Backspace))
        {
            //-GameInteraction-
            GameOver();
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 0;
            PauseGame(true);
        }
        if (paused == false && Input.GetKeyUp(KeyCode.Alpha1))
        {
            //-CameraStuff-
            frontCamera.enabled = true;
            interiorCamera.enabled = false;
            //-AudioStuff-
            cameraSwitching.Play();
        }
        else if (paused == false && Input.GetKeyUp(KeyCode.Alpha3))
        {
            //-CameraStuff-
            frontCamera.enabled = false;
            interiorCamera.enabled = true;
            //-AudioStuff-
            cameraSwitching.Play();
        }
    }

    //-ObjectInteraction-
    void CreateTheObject()
    {//Spawns a ship randomly within the CubeMatrix for the Engine System
        if (stopSpawning == false)
        {
            Rigidbody newSpaceObject = Instantiate(spaceObject, spawnpoint.position, spawnpoint.rotation) as Rigidbody;
            newSpaceObject.AddForce(transform.forward * objectMovementSpeed, ForceMode.VelocityChange);
            //-AudioStuff-
            //Maybe a sound that is attached to the object that constantly plays, this way it naturally gets louder the closer to the ship it gets
        }
    }

    //-ObjectInteraction-
    public void GotHit()
    {
        /*Checks Shield Level*/
        consoleText.DamageCargo(shieldCond, cargoCond);
        //-AudioStuff-
        //Something to let the player know that they got hit, and more importantly how bad it is
    }

    //-GameInteraction-
    public void GameOver()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
