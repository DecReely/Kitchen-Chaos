using System;
using System.Collections;
using System.IO.Ports;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArduinoConnection : MonoBehaviour
{
    private SerialPort dataStream = new SerialPort("COM5", 250000);
    
    private string receivedString;

    private int RIGHT_INTERACT;
    private int RIGHT_INTERACT_ALTERNATIVE;
    private int RIGHT_JOY_X;
    private int RIGHT_JOY_Y;
    private int LEFT_INTERACT;
    private int LEFT_INTERACT_ALTERNATIVE;
    private int LEFT_JOY_X;
    private int LEFT_JOY_Y;
    private int PULSE_1 = 70;
    private int PULSE_2 = 75;
    private int SOUND;
    
    private void Start()
    {
        //dataStream.Open();
    }

    private void Update()
    {
        //SerialDataReading();

        KeyboardIntegration();
    }

    private void SerialDataReading()
    {
        receivedString = dataStream.ReadLine();
        string[] datas = receivedString.Split(",");
        
        // // Todo: Buranın altına alınan tüm veriler variable'lara atanacak
        // RIGHT_JOY_X = Mathf.RoundToInt(float.Parse(datas[0]));
        // RIGHT_JOY_Y = Mathf.RoundToInt(float.Parse(datas[1]));
        // RIGHT_INTERACT = Mathf.RoundToInt(float.Parse(datas[2])); // Sıkıntı çıkabilir
        // RIGHT_INTERACT_ALTERNATIVE = Mathf.RoundToInt(float.Parse(datas[3]));
        // LEFT_JOY_X = Mathf.RoundToInt(float.Parse(datas[4]));
        // LEFT_JOY_Y = Mathf.RoundToInt(float.Parse(datas[5]));
        // LEFT_INTERACT = Mathf.RoundToInt(float.Parse(datas[6])); // Sıkıntı çıkabilir
        // LEFT_INTERACT_ALTERNATIVE = Mathf.RoundToInt(float.Parse(datas[7]));
        // SOUND = Mathf.RoundToInt(float.Parse(datas[8]));
        // PULSE_1 = Mathf.RoundToInt(float.Parse(datas[9])); // Todo: Comment kalkacak, alttaki silinecek.
        // //PULSE_1 = Random.Range(60, 80);
        // PULSE_2 = Mathf.RoundToInt(float.Parse(datas[10])); // Todo: Comment kalkacak, alttaki silinecek.
        // //PULSE_2 = Random.Range(60, 80);
        //
        // Debug.Log("rx: " + RIGHT_JOY_X);
        // Debug.Log("ry: " + RIGHT_JOY_Y);
        
        // Todo: buranın altını dikkate alma
        if (Input.GetKeyDown(KeyCode.A))
        {
            RIGHT_JOY_X = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RIGHT_JOY_X = 1;
        }
        else
        {
            RIGHT_JOY_X = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RIGHT_JOY_Y = -1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RIGHT_JOY_Y = 1;
        }
        else
        {
            RIGHT_JOY_Y = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RIGHT_INTERACT = 1;
        }
        else
        {
            RIGHT_INTERACT = 0;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RIGHT_INTERACT_ALTERNATIVE = 1;
        }
        else
        {
            RIGHT_INTERACT_ALTERNATIVE = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LEFT_JOY_X = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            LEFT_JOY_X = 1;
        }
        else
        {
            LEFT_JOY_X = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LEFT_JOY_Y = -1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            LEFT_JOY_Y = 1;
        }
        else
        {
            LEFT_JOY_Y = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LEFT_INTERACT = 1;
        }
        else
        {
            LEFT_INTERACT = 0;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            LEFT_INTERACT_ALTERNATIVE = 1;
        }
        else
        {
            LEFT_INTERACT_ALTERNATIVE = 0;
        }
        
        SOUND = Mathf.RoundToInt(float.Parse(datas[8]));
        
        AssignRandomPulseValues();
    }

    public void KeyboardIntegration()
    {
        // Todo: buranın altını dikkate alma
        if (Input.GetKey(KeyCode.A))
        {
            RIGHT_JOY_X = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RIGHT_JOY_X = 1;
        }
        else
        {
            RIGHT_JOY_X = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            RIGHT_JOY_Y = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            RIGHT_JOY_Y = 1;
        }
        else
        {
            RIGHT_JOY_Y = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RIGHT_INTERACT = 1;
        }
        else
        {
            RIGHT_INTERACT = 0;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RIGHT_INTERACT_ALTERNATIVE = 1;
        }
        else
        {
            RIGHT_INTERACT_ALTERNATIVE = 0;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LEFT_JOY_X = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            LEFT_JOY_X = 1;
        }
        else
        {
            LEFT_JOY_X = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            LEFT_JOY_Y = -1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            LEFT_JOY_Y = 1;
        }
        else
        {
            LEFT_JOY_Y = 0;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            LEFT_INTERACT = 1;
        }
        else
        {
            LEFT_INTERACT = 0;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LEFT_INTERACT_ALTERNATIVE = 1;
        }
        else
        {
            LEFT_INTERACT_ALTERNATIVE = 0;
        }
        
        //SOUND = Mathf.RoundToInt(float.Parse(datas[8]));
        
        AssignRandomPulseValues();
    }

    public void AssignRandomPulseValues()
    {
        if (Random.Range(0,100) < 2)
        {
            PULSE_1 += Random.Range(-1, 2); // Todo: Burası ve altı silinecek.
            PULSE_1 = Mathf.Clamp(PULSE_1, 60, 120);
        
            PULSE_2 += Random.Range(-1, 2); // Todo: Burası ve altı silinecek.
            PULSE_2 = Mathf.Clamp(PULSE_2, 60, 120);
        }
    }

    public int GetPulse1()
    {
        return PULSE_1;
    }
    
    public int GetPulse2()
    {
        return PULSE_2;
    }

    public int GetSound()
    {
        return SOUND;
    }
    
    public int GetJoyRINT()
    {
        return RIGHT_INTERACT;
    }
    
    public int GetJoyRINTALT()
    {
        return RIGHT_INTERACT_ALTERNATIVE;
    }

    public int GetJoyRX()
    {
        return RIGHT_JOY_X;
    }
    
    public int GetJoyRY()
    {
        return RIGHT_JOY_Y;
    }
    
    public int GetJoyLINT()
    {
        return LEFT_INTERACT;
    }
    
    public int GetJoyLINTALT()
    {
        return LEFT_INTERACT_ALTERNATIVE;
    }
    
    public int GetJoyLX()
    {
        return LEFT_JOY_X;
    }
    
    public int GetJoyLY()
    {
        return LEFT_JOY_Y;
    }
}
