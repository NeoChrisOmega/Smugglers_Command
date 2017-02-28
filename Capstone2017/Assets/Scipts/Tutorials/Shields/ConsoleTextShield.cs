using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleTextShield: MonoBehaviour
{
    #region Comment Keys

    //-ConsoleStuff-
    /*
    This is for anything that will appear at the bottom where the console is,
    anything that it represents, or effected by
    */

    //-AudioStuff-
    /*
    Anything that is, plays, or needs audio
    */

    //-ObjectInteraction-
    /*
    This will involve anything and everything that the game world can
    interact with itself. For example the objects hitting the ship,
    or the ship shooting a bullet, or spawnpoints
    */

    //-GameInteraction-
    /*
    Anything that can change more than just the stuff within this one level.
    For example, entering or exiting a level, variables that are needed outside
    this particular level, and other things like that
    */
    #endregion

    #region ConsoleText Variables
    //-ConsoleStuff-
    public Text shipCondition;

    public GameControllerT4 gameController;
    #endregion

    void Update()
    {
        //-ConsoleStuff-
        shipCondition.text = " Shield Condition: " + (gameController.shieldCond) + "\n Cargo Condition: " + gameController.cargoCond;
    }

    //-ObjectInteraction-
    public void DamageCargo(int shieldCond, string cargoCond)
    {
        if (shieldCond <= 0)
        {
            if (cargoCond == "Good")
            {
                //-ConsoleStuff-
                cargoCond = "Damaged";
                //-AudioStuff-
                //If the sound for cargo damage is different, add it here
            }
            else if (cargoCond == "Damaged")
            {
                //-ConsoleStuff-
                cargoCond = "!!!DANGER!!!";
                //-AudioStuff-
                //If the sound for each particular stage of the cargo damage is different, add it here
            }
            else
                //-GameInteraction-
                gameController.GameOver();
        }
        else
            //-ConsoleStuff-
            shieldCond--;
            //-AudioStuff-
            //If the sound is different for shield damage, add it here

        //-AudioStuff-
        //Put making sound based off of damage here if it is the same regardless of ship condition
    }
}