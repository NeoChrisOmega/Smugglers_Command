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
    int currentY;//This keeps track of where the camera rotation is
    int currentX;
    bool isMoving;

    public AudioSource menuInteraction;

    bool tutorialOptions = false;
    #endregion

    void Start()
    {
        currentX = System.Convert.ToInt32(levelSelectCamera.transform.position.x);
        currentY = System.Convert.ToInt32(levelSelectCamera.transform.position.y);
        PlayerPrefs.SetInt("Level1", 1);

        if (PlayerPrefs.GetInt("level1") == 1)
        {
            tutorial2Option.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tutorial2Option.GetComponent<Image>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            tutorial3Option.GetComponent<Image>().color = Color.white;
        }
        else
        {
            tutorial3Option.GetComponent<Image>().color = Color.white;
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
        Debug.Log(currentX + "\n" + currentY);
        #region MoveCamera
        if (tutorialOptions == false)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveToMainMenu");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveToSave");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveToStore");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveToTutorials");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                menuInteraction.Play();
                StopAllCoroutines();
                StartCoroutine("MoveToMissions");
            }
        }
        #endregion

        #region SaveButtons
        if (tutorialOptions == false)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                menuInteraction.Play();
                if (currentY == 30)
                {
                    SaveGame();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                menuInteraction.Play();
                if (currentY == 30)
                {
                    LoadGame();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Backspace))
            {
                menuInteraction.Play();
                if (currentY == 30)
                {
                    ExitGame();
                }
            }
        }
        #endregion

        #region TutorialButtons
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (currentX==35)
            {//This checks to see if you are on the tutorial screen
                if (tutorialOptions == false)
                {
                    ToggleTutorialOptions(true);
                }
                else if (tutorialOptions == true)
                {
                    ToggleTutorialOptions(false);
                }
            }
        }
        if (currentX != 35)
        {
            ToggleTutorialOptions(false);
        }
        #region OtherInputs
        if ( tutorialOptions == true)
        {//This part will be the pauseStuff are you sure...
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                menuInteraction.Play();
                ToggleTutorialOptions(false);
                tutorial1();
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                menuInteraction.Play();
                ToggleTutorialOptions(false);
                if (chooseTutorialOptions2.GetComponent<Image>().color == Color.grey)
                {
                    Debug.Log("errorSound.Play();");
                }
                else
                    tutorial2();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                menuInteraction.Play();
                ToggleTutorialOptions(false);
                if (chooseTutorialOptions3.GetComponent<Image>().color == Color.grey)
                {
                    Debug.Log("errorSound.Play();");
                }
                else
                    tutorial3();
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                menuInteraction.Play();
                ToggleTutorialOptions(false);
                if (chooseTutorialOptions4.GetComponent<Image>().color == Color.grey)
                {
                    Debug.Log("errorSound.Play();");
                }
                else
                    tutorial4();
            }
            /*if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                menuInteraction.Play();
                ToggleTutorialOptions(false);
                Debug.Log("tutorial5();");
            }*/
        }
        #endregion
        #endregion

        #region MissionButtons
        if (tutorialOptions == false)
        {
            if (currentY == -30)
            {
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    menuInteraction.Play();
                    StoryMode();
                }
            }
        }
        #endregion
    }

    #region SaveChoices
    public void SaveGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Debug.Log("You Pressed Save");
    }
    public void LoadGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Debug.Log("You Pressed Load");
    }
    public void ExitGame()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        Application.Quit();
    }
    #endregion

    void ToggleTutorialOptions(bool toggle)
    {
        if (toggle == true)
        {
            chooseTutorialOptions1.GetComponent<Image>().color = Color.grey;
            chooseTutorialOptions2.GetComponent<Image>().color = Color.grey;
            chooseTutorialOptions3.GetComponent<Image>().color = Color.grey;
            chooseTutorialOptions4.GetComponent<Image>().color = Color.grey;
            tutorialOptions = true;
        }
        if (toggle == false)
        {
            chooseTutorialOptions1.GetComponent<Image>().color = Color.white;
            chooseTutorialOptions2.GetComponent<Image>().color = Color.white;
            chooseTutorialOptions3.GetComponent<Image>().color = Color.white;
            chooseTutorialOptions4.GetComponent<Image>().color = Color.grey;
            tutorialOptions = false;
        }
    }

    #region TutorialChoices
    public void tutorial1()
    {//Engines
        //SceneManager.LoadScene("Tutorial1");
    }
    public void tutorial2()
    {//Turrets
        if (PlayerPrefs.GetInt("level1") == 1)
        {
            //SceneManager.LoadScene("Tutorial2");
        }
    }
    public void tutorial3()
    {//Shields
        if (PlayerPrefs.GetInt("level2") == 1)
        {
            PlayerPrefs.SetInt("distanceLeft", Random.Range(40, 100));
            //SceneManager.LoadScene("Tutorial3");
        }
    }
    public void tutorial4()
    {//Energy Management
        if (PlayerPrefs.GetInt("level3") == 1)
        {
            //SceneManager.LoadScene("Tutorial4");
        }
    }
    /*public void tutorial5()
    {//Crew and ship customization
        Debug.Log("tutorial 5");
    }*/
    #endregion

    void StoryMode()
    {
        SceneManager.LoadScene("StoryTutorial");
    }

    #region Movements
    IEnumerator MoveToStore()
    {//In order to get the realtime update of the camera moving, I need to IEnumerator the action
        if (currentY < 0)
        {
            while (currentY < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY += 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentY > 0)
            {
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY -= 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        while (currentX > -35)
        {//keeps moving the camera until it hits the point I wanted
            levelSelectCamera.transform.position = new Vector3(currentX -= 5, levelSelectCamera.transform.position.y , levelSelectCamera.transform.position.z);
            yield return null;
        }
    }
    IEnumerator MoveToTutorials()
    {
        if (currentY < 0)
        {
            while (currentY < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY += 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentY > 0)
            {
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY -= 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        while (currentX < 35)
        {
            levelSelectCamera.transform.position = new Vector3(currentX += 5, levelSelectCamera.transform.eulerAngles.y , levelSelectCamera.transform.position.z);
            yield return null;
        }
    }
    IEnumerator MoveToSave()
    {
        if (currentX < 0)
        {
            while (currentX < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(currentX += 5, levelSelectCamera.transform.position.y , levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentX > 0)
            {
                levelSelectCamera.transform.position = new Vector3(currentX -= 5, levelSelectCamera.transform.position.y, levelSelectCamera.transform.position.z);
                yield return null;
            }
        while (currentY < 30)
        {
            levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY +=5 , levelSelectCamera.transform.position.z);
            yield return null;
        }
    }
    IEnumerator MoveToMissions()
    {
        if (currentX < 0)
        {
            while (currentX < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(currentX += 5, levelSelectCamera.transform.position.y, levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentX > 0)
            {
                levelSelectCamera.transform.position = new Vector3(currentX -= 5, levelSelectCamera.transform.position.y, levelSelectCamera.transform.position.z);
                yield return null;
            }
        while (currentY > -30)
        {
            levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY -= 5, levelSelectCamera.transform.position.z);
            yield return null;
        }
    }
    IEnumerator MoveToMainMenu()
    {
        if (currentY < 0)
        {
            while (currentY < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY += 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentY > 0)
            {
                levelSelectCamera.transform.position = new Vector3(levelSelectCamera.transform.position.x, currentY -= 5, levelSelectCamera.transform.position.z);
                yield return null;
            }
        if (currentX < 0)
        {
            while (currentX < 0)
            {//This makes the movement an L shape when needed
                levelSelectCamera.transform.position = new Vector3(currentX += 5, levelSelectCamera.transform.position.y, levelSelectCamera.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentX > 0)
            {
                levelSelectCamera.transform.position = new Vector3(currentX -= 5, levelSelectCamera.transform.position.y, levelSelectCamera.transform.position.z);
                yield return null;
            }
    }
    #endregion
}