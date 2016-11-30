using UnityEngine;
using System.Collections;
using UnityEditor;

public class KillFoe : MonoBehaviour
{/*This is attached to the bullet, so that the bullet can trigger on the colliders
    of both the foes and the objects*/
    public GameControllerT2 gameController;

	void Update ()
    {//This will destroy the object when it goes too far out in space
        if (this.transform.position.z <= -50)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider ship)
    {//Checks to see if you hit, if you did destroys it
        
        /*This doesn't work, but I need to think of a way to do this later on in development
        GameObject referencFoeShip = gameController.foeShip;
        if (ship.gameObject == referencFoeShip)
        {
            Debug.Log("You killed it");
        }*/
        Destroy(ship.gameObject);
        //gameController.GotKill();
        Destroy(this.gameObject);
    }
}
