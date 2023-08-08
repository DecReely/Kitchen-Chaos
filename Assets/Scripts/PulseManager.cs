using System;
using UnityEngine;

public class PulseManager : MonoBehaviour
{
    private ArduinoConnection arduinoConnection;
    
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    private void Awake()
    {
        arduinoConnection = FindObjectOfType<ArduinoConnection>();
    }

    void Update()
    {
        HandlePlayerSpeed();
    }

    private void HandlePlayerSpeed()
    {
        int pulse1 = arduinoConnection.GetPulse1();
        int pulse2 = arduinoConnection.GetPulse2();

        #region Player1 Speed

        if (pulse1 < 75)
        {
            player1.SetMoveSpeed(Player.DefaultMoveSpeed);
        }
        else if (pulse1 <= 100)
        {
            player1.SetMoveSpeed(Player.DefaultMoveSpeed + (pulse1 - 75) * 0.5f);
        }
        else
        {
            player1.SetMoveSpeed(0f);
        }

        #endregion

        #region Player2 Speed

        if (pulse2 < 75)
        {
            player2.SetMoveSpeed(Player.DefaultMoveSpeed);
        }
        else if (pulse2 <= 100)
        {
            player2.SetMoveSpeed(Player.DefaultMoveSpeed + (pulse2 - 75) * 0.5f);
        }
        else
        {
            player2.SetMoveSpeed(0f);
        }

        #endregion
        
    }
}
