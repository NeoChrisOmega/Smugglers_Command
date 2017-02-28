using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleTextEngines: MonoBehaviour
{
    public Text distanceToEnd;
    float distanceLeft;
    string cargoCondition;

    public GameControllerT1 gameController;
    
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
        {
            PlayerPrefs.SetInt("level1", 1);
            gameController.GameOver();
        }

    }
    
    public void DamageCargo()
    {
        if (cargoCondition == "Good")
        {
            cargoCondition = "Damaged";
        }
        else if (cargoCondition == "Damaged")
        {
            cargoCondition = "!!!DANGER!!!";
        }
        else
            gameController.GameOver();
    }
}
