using UnityEngine;
using System.Collections;

public class MoveShipShield : MonoBehaviour
{
    #region Comment Keys

    //-ObjectInteraction-
    /*
    This will involve anything and everything that the game world can
    interact with itself. For example the objects hitting the ship,
    or the ship shooting a bullet, or spawnpoints
    */
    #endregion

    public GameControllerT4 gameController;

    //-ObjectInteraction-
    public void OnTriggerEnter(Collider spaceObject)
    {//If this collides with one of the objects, kill the object and damage ship
        Destroy(spaceObject.gameObject);
        gameController.GotHit();
    }
}