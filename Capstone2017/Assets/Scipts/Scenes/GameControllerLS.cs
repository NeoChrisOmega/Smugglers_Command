using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerLS : MonoBehaviour
{
    #region Variable Stuff
    /*public GameObject saveTab;//This is what will store the gameInfo
    public GameObject missionsTab;//This is what will randomize the levels
    public GameObject instructionsTab;//This is the ship and crew information
    public GameObject tutorialTab;//This will show what tutorials are available*/
    public GameObject popUpDisplay;
    public GameObject tutorial1Option;
    public GameObject tutorial2Option;
    public GameObject tutorial3Option;
    public GameObject tutorial4Option;
    public GameObject chooseTutorialOptions1, chooseTutorialOptions2, chooseTutorialOptions3, chooseTutorialOptions4;

    public Camera levelSelectCamera;//This is the camera
    float yRotation;//This keeps track of where the camera rotation is
    float xRotation;
    bool isMoving;

    public AudioSource menuInteraction;

    bool tutorialOptions = false;
    #endregion

    void Start()
    {
        //This is for playtesting
        PlayerPrefs.SetInt("Level2", 1);
        //This is for playtesting

        if (PlayerPrefs.GetInt("level1") == 1)
        {
            tutorial2Option.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tutorial2Option.GetComponent<Image>().color = Color.grey;
        }
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            tutorial3Option.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tutorial3Option.GetComponent<Image>().color = Color.grey;
        }
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            tutorial4Option.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tutorial4Option.GetComponent<Image>().color = Color.grey;
        }
    }

    void Update()//I still need to update the x menus
    {//This is for all the button press checks
        #region MoveCamera
        if (tutorialOptions == false)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveBack");
            }
            #region OtherInputs
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveUp");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveLeft");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveRight");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveDown");
            }
        }
        #endregion
        #endregion

        #region SaveButtons
        if (tutorialOptions == false)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                menuInteraction.Play();
                if (yRotation < 1 && yRotation > -1 && xRotation < -1)
                {
                    SaveGame();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                menuInteraction.Play();
                if (yRotation < 1 && yRotation > -1 && xRotation < -1)
                {
                    LoadGame();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Backspace))
            {
                menuInteraction.Play();
                if (yRotation < 1 && yRotation > -1 && xRotation < -1)
                {
                    ExitGame();
                }
            }
        }
        #endregion

        #region TutorialButtons
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (xRotation < 1 && xRotation > -1 && yRotation > 1)
            {//This checks to see if you are on the tutorial screen
                if (tutorialOptions == false)
                {
                    chooseTutorialOptions1.GetComponent<Image>().color = Color.grey;
                    chooseTutorialOptions2.GetComponent<Image>().color = Color.grey;
                    chooseTutorialOptions3.GetComponent<Image>().color = Color.grey;
                    chooseTutorialOptions4.GetComponent<Image>().color = Color.grey;
                    tutorialOptions = true;
                }
                else if (tutorialOptions == true)
                {
                    chooseTutorialOptions1.GetComponent<Image>().color = Color.white;
                    chooseTutorialOptions2.GetComponent<Image>().color = Color.white;
                    chooseTutorialOptions3.GetComponent<Image>().color = Color.white;
                    chooseTutorialOptions4.GetComponent<Image>().color = Color.grey;
                    tutorialOptions = false;
                }
            }
        }
        #region OtherInputs
        if ( tutorialOptions == true)
        {//This part will be the pauseStuff are you sure...
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                menuInteraction.Play();
                tutorialOptions = false;
                tutorial1();
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                menuInteraction.Play();
                tutorialOptions = false;
                tutorial2();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                menuInteraction.Play();
                tutorialOptions = false;
                tutorial3();
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                menuInteraction.Play();
                tutorialOptions = false;
                tutorial4();
            }
            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                menuInteraction.Play();
                tutorialOptions = false;
                tutorial5();
            }
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
        Application.Quit();
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
        if (PlayerPrefs.GetInt("level1") == 1)
        {
            SceneManager.LoadScene("Tutorial2");
        }
    }
    public void tutorial3()
    {//Shields
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            PlayerPrefs.SetInt("distanceLeft", Random.Range(40, 100));
            SceneManager.LoadScene("Tutorial3");
        }
    }
    public void tutorial4()
    {//Energy Management
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            SceneManager.LoadScene("Tutorial4");
        }
    }
    public void tutorial5()
    {//Crew and ship customization
        Debug.Log("tutorial 5");
    }
    #endregion
}

/* Notes
    -I will have the 4 placeholder GameObjects represent my focus

    -The saved data I won't need to remember until I add ship customization

    -Tutorials I will start with <<<<<<<

    -MissionOptions I should do once I have the tutorial completed

    -Ship data I am leaving for after I have the gameplay finished










*/
