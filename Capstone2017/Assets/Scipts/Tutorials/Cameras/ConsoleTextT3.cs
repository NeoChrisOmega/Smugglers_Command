using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ConsoleTextT3 : MonoBehaviour
{
    public Text displayText;
    float distanceLeft;
    string distanceText;
    public GameControllerT3 gameController;
    
    void Start ()
    {
        int setDistance = PlayerPrefs.GetInt("distanceLeft");
        if (setDistance == 0)
        {
            PlayerPrefs.SetInt("level3", 1);
            setDistance = 60;
        }
        distanceLeft = setDistance;
    }
    void Update()
    {
        if (distanceLeft > .1)
        {
            distanceLeft = distanceLeft - Time.deltaTime;
            distanceText = "Distance left to destination: "+Math.Round(distanceLeft, 2)+" Lightyears\n";
        }
        else
        {
            PlayerPrefs.SetInt("level3", 1);
            gameController.GameOver();
        }
        displayText.text = distanceText;
    }
    
    public void DamageCargo()
    {
    }
}
