using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameControllerMM : MonoBehaviour
{
    //public Camera mainCamera;//This is the camera
    //float yRotation;//This keeps track of where the camera rotation is
    public AudioSource menuInteraction;
    public GameObject menus;
    int currentX;

    void Start()
    {
        currentX = Convert.ToInt32(menus.transform.position.x);
    }

    void Update()
    {
        //Debug.Log(menus.transform.position.x);
        #region Inputs
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            if (currentX != 0)
            {
                StartCoroutine(MoveToMainMenu());
            }
            else
            {
                //errorSound.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            if (currentX < 35)
            {
                StartCoroutine(MoveToInstructions());
            }
            else
            {
                //errorSound.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            menuInteraction.Play();
            StopAllCoroutines();
            if (currentX > -35)
            {
                StartCoroutine(MoveToCredits());
            }
            else
            {
                //errorSound.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            menuInteraction.Play();
            if (currentX == 0)
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("Prefabs Deleted");
                SceneManager.LoadScene("Menus");
            }
        }
        #endregion
    }

    IEnumerator MoveToMainMenu()
    {
        if (currentX < 0)
        {
            while (currentX < 0)
            {
                menus.transform.position = new Vector3(currentX = currentX + 5, menus.transform.position.y, menus.transform.position.z);
                yield return null;
            }
        }
        else
            while (currentX > 0)
            {
                menus.transform.position = new Vector3(currentX = currentX - 5, menus.transform.position.y, menus.transform.position.z);
                yield return null;
            }
    }
    IEnumerator MoveToInstructions()
    {//In order to get the realtime update of the camera moving, I need to IEnumerator the action
        while (currentX < 35)
        {//keeps moving the camera until it hits the point I wanted
            menus.transform.position = new Vector3(currentX = currentX + 5, menus.transform.position.y, menus.transform.position.z);
            yield return null;//This is what updates the movement in realtime
        }
    }
    IEnumerator MoveToCredits()
    {
        while (currentX > -35)
        {
            menus.transform.position = new Vector3(currentX = currentX - 5, menus.transform.position.y, menus.transform.position.z);
            yield return null;
        }
    }
}
