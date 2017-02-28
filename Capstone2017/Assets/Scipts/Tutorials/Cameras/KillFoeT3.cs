using UnityEngine;
using System.Collections;

public class KillFoeT3 : MonoBehaviour
{/*This is attached to the bullet, so that the bullet can trigger on the colliders
    of both the foes and the objects*/
	void Update ()
    {//This will destroy the object when it goes too far out in space
        if (this.transform.position.z <= -50 || this.transform.position.z >= 50)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider ship)
    {//Checks to see if you hit, if you did destroys it
        Destroy(this.gameObject);
    }
}
