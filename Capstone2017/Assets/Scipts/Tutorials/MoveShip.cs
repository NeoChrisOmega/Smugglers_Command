using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour
{//This goes onto the ship for the Engines System
    public float movementSpeed;
    float currentX, currentY;
    public GameControllerT1 gameController;

    void Update()
    {
        #region MovementAndRestrictions
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            StartCoroutine("MoveLeft");
        }
        #region OtherStuff
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine("MoveRight");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            StartCoroutine("MoveUp");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            StartCoroutine("MoveDown");
        }
        #endregion
        #endregion
    }

    #region Movements
    IEnumerator MoveLeft()
    {
        if (currentX >= -1.5)
        {
            while (currentX > currentX - 1.5)
            {
                this.transform.position = new Vector3(currentX += currentX - 0.3f, currentY, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
    }
    #region OtherMovements
    IEnumerator MoveRight()
    {
        if (currentX <= 1.5)
        {
            while (currentX < currentX + 1.5)
            {
                this.transform.position = new Vector3(currentX + 0.3f, currentY, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
    }
    IEnumerator MoveUp()
    {
        if (currentY >= 0)
        {
            while (currentY > currentY - 1.5)
            {
                this.transform.position = new Vector3(currentX, currentY - 0.3f, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
    }
    IEnumerator MoveDown()
    {
        if (currentY >= 0)
        {
            while (currentY > currentY + 1.5)
            {
                this.transform.position = new Vector3(currentX, currentY + 0.3f, this.transform.position.z);
                yield return null;
            }
        }
        else
            Debug.Log("This will play an Error.Sound");
    }
    #endregion
    #endregion

    public void OnTriggerEnter(Collider spaceObject)
    {//If this collides with one of the objects, kill the object and damage ship
        Destroy(spaceObject.gameObject);
        gameController.GotHit();
    }
}
