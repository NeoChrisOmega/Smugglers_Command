using UnityEngine;
using System.Collections;

public class MoveShipT3 : MonoBehaviour
{//This goes onto the ship for the Engines System
    float currentX, currentY;
    bool isMoving;
    public GameControllerT3 gameController;
    
    void Start()
    {
        currentX = this.transform.position.x;
        currentY = this.transform.position.y;
        isMoving = false;
    }
    void Update()
    {
        if (gameController.paused != true && gameController.frontCamera.enabled == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (currentX > -3)
                {
                    this.transform.position = new Vector3(currentX = currentX - 1, this.transform.position.y, this.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #region OtherStuff
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (currentX <= 3)
                {
                    this.transform.position = new Vector3(currentX = currentX + 1, this.transform.position.y, this.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (currentY <= 1.5)
                {
                    this.transform.position = new Vector3(this.transform.position.x, currentY = currentY + 1, this.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (currentY > -1.5)
                {
                    this.transform.position = new Vector3(this.transform.position.x, currentY = currentY - 1, this.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #endregion
        }
    }
    
    public void OnTriggerEnter(Collider spaceObject)
    {//If this collides with one of the objects, kill the object and damage ship
        Debug.Log("Trigger Enter");
        Destroy(spaceObject.gameObject);
        gameController.GotHit();
    }
}