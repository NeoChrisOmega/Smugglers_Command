using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerLS : MonoBehaviour
{
    public GameObject savedData1;//This is what will store the gameInfo
    public GameObject missionOptions;//This is what will randomize the levels
    public GameObject shipData;//This is the ship and crew information
    public GameObject tutorialsCompleted;//This will show what tutorials are available

    public Camera levelSelectCamera;//This is the camera
    float yRotation;//This keeps track of where the camera rotation is
    float xRotation;

    bool tutorialOptions = false;

    void Update()//I still need to update the x menus
    {//This is for all the button press checks
        #region MoveCamera
        if (Input.GetKeyUp(KeyCode.Alpha1) && tutorialOptions == false)
        {
            MoveBack();
        }
        #region OtherInputs
        if (Input.GetKeyUp(KeyCode.Alpha2) && tutorialOptions == false)
        {
            MoveUp();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) && tutorialOptions == false)
        {
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4) && tutorialOptions == false)
        {
            MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5) && tutorialOptions == false)
        {
            MoveDown();
        }
        #endregion
        #endregion
        #region SaveButtons
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (yRotation < 1 && yRotation > -1 && xRotation < -1)
            {
                SaveGame();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (yRotation < 1 && yRotation > -1 && xRotation < -1)
            {
                LoadGame();
            }
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (yRotation < 1 && yRotation > -1 && xRotation < -1)
            {
                ExitGame();
            }
        }
        #endregion
        #region TutorialButtons
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (xRotation < 1 && xRotation > -1 && yRotation > 1)
            {
                if (tutorialOptions == false)
                {
                    tutorialOptions = true;
                }
                else if (tutorialOptions == true)
                {
                    tutorialOptions = false;
                }
            }
        }
        #region OtherInputs
        if (Input.GetKeyUp(KeyCode.Alpha1) && tutorialOptions == true)
        {
            tutorialOptions = false;
            tutorial1();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2) && tutorialOptions == true)
        {
            tutorialOptions = false;
            tutorial2();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) && tutorialOptions == true)
        {
            tutorialOptions = false;
            tutorial3();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4) && tutorialOptions == true)
        {
            tutorialOptions = false;
            tutorial4();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5) && tutorialOptions == true)
        {
            tutorialOptions = false;
            tutorial5();
        }
        #endregion
        #endregion
    }
    #region TheMovements
    public void MoveLeft()
    {//Turns the camera to the left side
        StartCoroutine(MoveToStore());
    }
    #region OtherStuff
    public void MoveRight()
    {//Turns the camera to the rights side
        StartCoroutine(MoveToTutorials());
    }
    public void MoveUp()
    {//Turns the camera to the rights side
        StartCoroutine(MoveToSave());
    }
    public void MoveDown()
    {//Turns the camera to the rights side
        StartCoroutine(MoveToMissions());
    }
    public void MoveBack()
    {//Turns the camera back to the center
        StartCoroutine(MoveToMainMenu());
    }
    public void SaveGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Debug.Log("You Pressed Save");
    }
    #region OtherMovements
    public void LoadGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Debug.Log("You Pressed Load");
    }
    public void ExitGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Debug.Log("You Pressed Exit");
    }
    #endregion
    #endregion

    IEnumerator MoveToStore()
    {//In order to get the realtime update of the camera moving, I need to IEnumerator the action
        if (xRotation <= -.1)
        {
            while (xRotation <= 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation++, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
        }
        else
            while (xRotation >= 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation--, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
        while (yRotation >= -70)
        {//keeps moving the camera until it hits the point I wanted
            levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation--, 0);
            yield return null;//This is what updates the movement in realtime
        }
    }
    #region OtherMovements
    IEnumerator MoveToTutorials()
    {
        if (xRotation < -1)
        {
            while (xRotation < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation++, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
        }
        else
            while (xRotation > 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation--, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
        while (yRotation < 70)
        {
            levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation++, 0);
            yield return null;
        }
    }
    IEnumerator MoveToSave()
    {
        if (yRotation < -1)
        {
            while (yRotation < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation++, 0);
                yield return null;
            }
        }
        else
            while (yRotation > 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation--, 0);
                yield return null;
            }
        while (xRotation > -70)
        {
            levelSelectCamera.transform.eulerAngles = new Vector3(xRotation--, levelSelectCamera.transform.eulerAngles.y, 0);
            yield return null;
        }
    }
    IEnumerator MoveToMissions()
    {
        if (yRotation < -1)
        {
            while (yRotation < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation++, 0);
                yield return null;
            }
        }
        else
            while (yRotation > 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation--, 0);
                yield return null;
            }
        while (xRotation < 70)
        {
            levelSelectCamera.transform.eulerAngles = new Vector3(xRotation++, levelSelectCamera.transform.eulerAngles.y, 0);
            yield return null;
        }
    }
    IEnumerator MoveToMainMenu()
    {
        if (yRotation < -1)
        {//This checks to see if the camera is on the left of the main menu
            while (yRotation < 0)
            {
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation++, 0);
                yield return null;
            }
        }
        else//This checks to see if the camera is on the right of the main menu
            while (yRotation > 0)
            {
                levelSelectCamera.transform.eulerAngles = new Vector3(levelSelectCamera.transform.eulerAngles.x, yRotation--, 0);
                yield return null;
            }
        if (xRotation < -1)
        {//This checks to see if the camera is on the down of the main menu
            while (xRotation < 0)
            {
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation++, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
        }
        else//This checks to see if the camera is on the up of the main menu
            while (xRotation > 0)
            {
                levelSelectCamera.transform.eulerAngles = new Vector3(xRotation--, levelSelectCamera.transform.eulerAngles.y, 0);
                yield return null;
            }
    }
    #endregion
    #endregion

    #region TutorialChoices
    public void tutorial1()
    {//Engines
        SceneManager.LoadScene("Tutorial1");
    }
    public void tutorial2()
    {//Turrets
        SceneManager.LoadScene("Tutorial2");
    }
    public void tutorial3()
    {//Shields
        Debug.Log("tutorial 3");
    }
    public void tutorial4()
    {//Energy Management
        Debug.Log("tutorial 4");
    }
    public void tutorial5()
    {//Crew and ship customization
        Debug.Log("tutorial 5");
    }
    #endregion
}





/*
    -I will have the 4 placeholder GameObjects represent my focus

    -The saved data I won't need to remember until I add ship customization

    -Tutorials I will start with <<<<<<<

    -MissionOptions I should do once I have the tutorial completed

    -Ship data I am leaving for after I have the gameplay finished










*/
