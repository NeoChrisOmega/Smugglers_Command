using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleTextT3 : MonoBehaviour
{
    public Text displayText;
    int shieldLayers;
    float distanceLeft;
    string cargoText;
    string distanceText;
    string shieldText;
    public GameControllerT3 gameController;
    
    void Start ()
    {
        PlayerPrefs.SetInt("cargoText", 3);
        Debug.Log(PlayerPrefs.GetInt("cargoText"));
        cargoText = "Good";
        shieldLayers = 3;
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
        shieldText = " Shield Layers Remaining: " + shieldLayers + "\n";
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
        displayText.text = distanceText + shieldText + " Cargo Condition is: "+ cargoText;
    }
    
    public void DamageCargo()
    {
        if (shieldLayers <= 0)
        {
            if (PlayerPrefs.GetInt("cargoText") == 3)
            {
                cargoText = "Fair";
                PlayerPrefs.SetInt("cargoText", 2);
            }
            else if (PlayerPrefs.GetInt("cargoText") == 2)
            {
                cargoText = "Poor";
                PlayerPrefs.SetInt("cargoText", 1);
            }
            else if (PlayerPrefs.GetInt("cargoText") == 1)
            {
                PlayerPrefs.SetInt("cargoText", 0);
                gameController.GameOver();
            }
            else
            {
                Debug.Log("error in DamageCargo");
            }
        }
        else
        {
            shieldLayers--;
        }
    }
}
