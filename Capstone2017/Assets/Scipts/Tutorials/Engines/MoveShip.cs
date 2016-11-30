using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour
{//This goes onto the ship for the Engines System
    float currentX, currentY;
    bool isMoving;
    public GameControllerT1 gameController;


    void Start()
    {
        currentX = this.transform.position.x;
        currentY = this.transform.position.y;
        isMoving = false;
    }

    void Update()
    {
        /*if (gameController.paused != true)
        {
            #region MovementAndRestrictions
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveLeft");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #region OtherStuff
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveRight");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveUp");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.A))
            {
                if (isMoving == false)
                {
                    isMoving = true;
                    StartCoroutine("MoveDown");
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #endregion
            #endregion
        }*/
    }

    #region Movements
    IEnumerator MoveLeft()
    {
        if (currentX > -3)
        {
            float targetX = currentX - 1.5f;
            while (currentX > targetX)
            {
                this.transform.position = new Vector3(currentX = currentX - 0.1f, this.transform.position.y, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    #region OtherMovements
    IEnumerator MoveRight()
    {
        if (currentX <= 3)
        {
            float targetX = currentX + 1.5f;
            while (currentX < targetX)
            {
                this.transform.position = new Vector3(currentX = currentX + 0.1f, this.transform.position.y, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    
    IEnumerator MoveUp()
    {
        if (currentY <= 0.5)
        {
            float targetY = currentY + 1.5f;
            while (currentY < targetY)
            {
                this.transform.position = new Vector3(this.transform.position.x, currentY = currentY + 0.1f, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    IEnumerator MoveDown()
    {
        if (currentY > -2.5)
        {
            float targetY = currentY - 1.5f;
            while (currentY > targetY)
            {
                this.transform.position = new Vector3(this.transform.position.x, currentY = currentY - 0.1f, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
        isMoving = false;
    }
    #endregion
    #endregion


    public void OnTriggerEnter(Collider spaceObject)
    {//If this collides with one of the objects, kill the object and damage ship
        Debug.Log("Trigger Enter");
        Destroy(spaceObject.gameObject);
        gameController.GotHit();
    }
}