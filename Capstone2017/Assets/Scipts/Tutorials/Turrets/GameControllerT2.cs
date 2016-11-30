using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerT2 : MonoBehaviour
{
    #region Variable Stuff
    public GameObject spawnObject;
    public Transform[] spawnpoints;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab
    public GameObject foeShip;
    public GameObject[] filledPoints;
    //public int[] filledPointsIDs;

    public bool paused = true;
    public Canvas pauseMenu;
    public ConsoleTextTurrets consoleText;
    #endregion

    void Start ()
    {
        #region Default Setup
        Time.timeScale = 0;
        PauseGame(true);
        spawnpoints[0] = spawnObject.transform.Find("Left2Top");
        spawnpoints[1] = spawnObject.transform.Find("Left2Middle");
        spawnpoints[2] = spawnObject.transform.Find("Left2Bottom");
        spawnpoints[3] = spawnObject.transform.Find("Left1Top");
        spawnpoints[4] = spawnObject.transform.Find("Left1Middle");
        spawnpoints[5] = spawnObject.transform.Find("Left1Bottom");
        spawnpoints[6] = spawnObject.transform.Find("CenterTop");
        spawnpoints[7] = spawnObject.transform.Find("CenterMiddle");
        spawnpoints[8] = spawnObject.transform.Find("CenterBottom");
        spawnpoints[9] = spawnObject.transform.Find("Right1Top");
        spawnpoints[10] = spawnObject.transform.Find("Right1Middle");
        spawnpoints[11] = spawnObject.transform.Find("Right1Bottom");
        spawnpoints[12] = spawnObject.transform.Find("Right2Top");
        spawnpoints[13] = spawnObject.transform.Find("Right2Middle");
        spawnpoints[14] = spawnObject.transform.Find("Right2Bottom");
        #endregion
        
        InvokeRepeating("CreateTheObject", 1.0f, 2f);
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
    }

    void CreateTheObject()
    {//Spawns a ship randomly within the CubeMatrix for the Engine System
        int randomSpawn = Random.Range(0, 15); //This randomizes the spawnpoint
        if (filledPoints[randomSpawn] != null)
        {
            randomSpawn = CheckTheSpawn();
        }
        GameObject newFoeShip = Instantiate(foeShip, spawnpoints[randomSpawn].position, spawnpoints[0].rotation) as GameObject;
        filledPoints[randomSpawn] = newFoeShip;


        
    }

    int CheckTheSpawn()
    {
        int newSpawn = Random.Range(0, 15);
        while (filledPoints[newSpawn] != null)
        {
            newSpawn = Random.Range(0, 15);
        }
        return newSpawn;
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

    public void GotHit()
    {
        //Checks Shield Level
        consoleText.DamageCargo();
    }

    public void GotKill()
    {
        consoleText.GotAKill();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}