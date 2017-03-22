using UnityEngine;
using System.Collections;

public class MoveShipT3 : MonoBehaviour
{//This goes onto the ship for the Engines System
    float currentX, currentY;
    bool isMoving;
    public GameControllerT3 gameController;
    public GameObject ship;
    
    void Start()
    {
        currentX = ship.transform.position.x;
        currentY = ship.transform.position.y;
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
                    ship.transform.position = new Vector3(currentX -= .5f, ship.transform.position.y, ship.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            #region OtherStuff
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (currentX <= 3)
                {
                    ship.transform.position = new Vector3(currentX += .5f, ship.transform.position.y, ship.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (currentY <= 1.5)
                {
                    ship.transform.position = new Vector3(ship.transform.position.x, currentY += .5f, ship.transform.position.z);
                }
                else
                    Debug.Log("Error Sound plays");
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (currentY > -1.5)
                {
                    ship.transform.position = new Vector3(ship.transform.position.x, currentY -= .5f, ship.transform.position.z);
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
        gameController.GotHit(true);
    }
}