using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleTextT3 : MonoBehaviour
{
    public Text displayText;
    float distanceLeft;
    string distanceText;
    string shieldText;
    public GameControllerT3 gameController;
    
    void Start ()
    {
        PlayerPrefs.SetInt("cargoText", 3);
        Debug.Log(PlayerPrefs.GetInt("cargoText"));
        gameController.shieldLayers = 3;
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
        shieldText = " Shield Layers Remaining: " + gameController.shieldLayers + "\n";
        if (distanceLeft > 10.02)
        {
            distanceLeft = distanceLeft - Time.deltaTime;
            distanceText = " Distance left to destination: " + (distanceLeft * 100000) + "\n";
        }
        else
        {
            PlayerPrefs.SetInt("level3", 1);
            gameController.GameOver();
        }
        displayText.text = distanceText + shieldText + " Cargo Condition is: "+ gameController.cargoText;
    }
    
    public void DamageCargo()
    {
    }
}
