using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerMM : MonoBehaviour
{
    public Camera mainCamera;//This is the camera
    float yRotation;//This keeps track of where the camera rotation is
    public AudioSource menuInteraction;

    void Update()
    {//This is for all the button press checks
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            StartCoroutine(MoveToMainMenu());
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            StartCoroutine(MoveToCredits());
        }
        #region OtherInputs
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            StartCoroutine(MoveToInstructions());
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            menuInteraction.Play();
            if (yRotation <1 && yRotation >-1)
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("Prefabs Deleted");
                SceneManager.LoadScene("LevelSelect");
            }
        }
        #endregion
    }

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
}
