using UnityEngine;
using System.Collections;

public class GameControllerT1 : MonoBehaviour
{
    #region EngineSystem Variables
    public GameObject ship;
    float shipMovementSpeed;
    public MoveShip moveShip;

    bool AIMoving;
    
    public Transform[] spawnpoints;// This is a list of the empty gameobject posisions//public GameObject spaceObject; // This is the EnemyShip prefab
    public Rigidbody spaceObject;
    float objectMovementSpeed = -20.0f;
    #endregion

    // Use this for initialization
    void Start ()
    {
        #region EngineSystem Setup
        shipMovementSpeed = 3;
        moveShip.movementSpeed = shipMovementSpeed;
        InvokeRepeating("CreateTheObject", 1.0f, .5f);
        #endregion
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void CreateTheObject()
    {//Spawns a ship randomly within the CubeMatrix for the Engine System
        int randomSpawn = Random.Range(0, 15); //This randomizes the spawnpoint
        Rigidbody newSpaceObject = Instantiate(spaceObject, spawnpoints[randomSpawn].position, spawnpoints[0].rotation) as Rigidbody;
        newSpaceObject.AddForce(transform.forward * objectMovementSpeed, ForceMode.VelocityChange);
    }

    public void GotHit()
    {
        //I will keep record of the damage here
    }
}
