using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleText : MonoBehaviour
{
    public Text distanceToEnd;
    float distanceLeft;
    string cargoCondition;

    public GameControllerT1 gameController;

    // Use this for initialization
    void Start ()
    {
        cargoCondition = "Good";
        distanceLeft = 60;
    }

    void Update()
    {
        if (distanceLeft > 10.02)
        {
            distanceLeft = distanceLeft - Time.deltaTime;
            distanceToEnd.text = " Distance left to destination: " + (distanceLeft * 100000) + "\n Cargo Condition: " + cargoCondition;
        }
        else
            gameController.GameOver();

    }
    
    public void DamageCargo()
    {
        if (cargoCondition == "Good")
        {
            cargoCondition = "Fair";
        }
        else if (cargoCondition == "Fair")
        {
            cargoCondition = "Poor";
        }
        //else
        //    gameController.GameOver();
    }
}
