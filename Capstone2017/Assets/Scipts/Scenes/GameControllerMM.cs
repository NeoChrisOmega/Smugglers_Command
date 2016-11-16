using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerMM : MonoBehaviour
{
    public Camera mainCamera;//This is the camera
    float yRotation;//This keeps track of where the camera rotation is

    void Update()
    {//This is for all the button press checks
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            MoveBack();
        }
        #region OtherInputs
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (yRotation <1 && yRotation >-1)
            {
                StartGame();
            }
        }
        #endregion
    }
    #region TheMovements
    public void StartGame ()
    {//Goes to the LevelSelect scene, should pass off any information that LS GameController should know
        SceneManager.LoadScene("LevelSelect");
    }
    #region OtherMovements
    public void MoveLeft()
    {//Turns the camera to the left side
        StartCoroutine(MoveToInstructions());
    }
    public void MoveRight()
    {//Turns the camera to the rights side
        StartCoroutine(MoveToCredits());
    }
    public void MoveBack()
    {//Turns the camera back to the center
        StartCoroutine(MoveToMainMenu());
    }
    #endregion

    IEnumerator MoveToInstructions()
    {//In order to get the realtime update of the camera moving, I need to IEnumerator the action
        while (yRotation >= -70)
        {//keeps moving the camera until it hits the point I wanted
            mainCamera.transform.eulerAngles = new Vector3(0, yRotation--, 0);
            yield return null;//This is what updates the movement in realtime
        }
    }
    #region OtherMovements
    IEnumerator MoveToCredits()
    {
        while (yRotation <= 70)
        {
            mainCamera.transform.eulerAngles = new Vector3(0, yRotation++, 0);
            yield return null;
        }
    }
    IEnumerator MoveToMainMenu()
    {
        if (yRotation <0 )
        {
            while (yRotation < 0)
            {
                mainCamera.transform.eulerAngles = new Vector3(0, yRotation++, 0);
                yield return null;
            }
        }
        else
            while (yRotation > 0)
            {
                mainCamera.transform.eulerAngles = new Vector3(0, yRotation--, 0);
                yield return null;
            }
    }
    #endregion
#endregion
}
