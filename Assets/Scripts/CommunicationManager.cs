using UnityEngine;

public class CommunicationManager : MonoBehaviour
{
    private ArduinoConnection arduinoConnection;
    
    private int healthyCommunication;

    private const int LoudThreshold = 5;

    private void Awake()
    {
        arduinoConnection = FindObjectOfType<ArduinoConnection>();
    }

    private void Start()
    {
        healthyCommunication = 100;
    }

    private void Update()
    {
        if (arduinoConnection.GetSound() >= LoudThreshold)
        {
            healthyCommunication--;
        }
    }

    public int GetHealthCommunication()
    {
        return 90;
        
        return healthyCommunication;
    }

}
