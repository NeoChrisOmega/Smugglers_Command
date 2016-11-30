﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleTextTurrets : MonoBehaviour
{
    public Text toKillText;
    int enemiesLeft;
    string cargoCondition;

    public GameControllerT2 gameController;
    
    void Start ()
    {
        cargoCondition = "Good";
        enemiesLeft = 60;
    }

    void Update()
    {
        if (enemiesLeft > 0)
        {
            toKillText.text = " Enemies to kill: " + enemiesLeft + "\n Cargo Condition: " + cargoCondition;
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
        else
            gameController.GameOver();
    }

    public void GotAKill()
    {
        enemiesLeft--;
        Debug.Log(enemiesLeft);
    }
}