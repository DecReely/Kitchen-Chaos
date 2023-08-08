using TMPro;
using UnityEngine;

public class PulseUI : MonoBehaviour
{
    private ArduinoConnection arduinoConnection;
    private TextMeshProUGUI textMeshProUGUI;

    private bool isPlayerOne;

    private const int HighPulseThreshold = 100;

    private void Awake()
    {
        arduinoConnection = FindObjectOfType<ArduinoConnection>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        isPlayerOne = transform.parent.parent.name == "Player1";
    }

    private void Start()
    {
        InvokeRepeating(nameof(AssignRandomPulse), 0, 0.1f);
    }

    private void AssignRandomPulse()
    {
        if (isPlayerOne)
        {
            if (arduinoConnection.GetPulse1() >= HighPulseThreshold)
            {
                textMeshProUGUI.SetText("HIGH PULSE!!");
            }
            else
            {
                textMeshProUGUI.SetText(arduinoConnection.GetPulse1().ToString());
            }
        }
        else
        {
            if (arduinoConnection.GetPulse2() >= HighPulseThreshold)
            {
                textMeshProUGUI.SetText("HIGH PULSE!!");
            }
            else
            {
                textMeshProUGUI.SetText(arduinoConnection.GetPulse2().ToString());
            }
        }
    }
}
