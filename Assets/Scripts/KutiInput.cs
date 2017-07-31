using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class KutiInput
{
   private static KutiInput _Instance;

    public static KutiInput Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new KutiInput();
                _Instance.InitializeFileStreams();
            }
            return _Instance;
        }
    }

    // GPIO Port numbers used for input correspond with accodring index in correspondingKutiButtons
    private  int[] gpioPorts = new int[7] {2, 3, 4, 5, 6, 8, 15};

    private  EKutiButton[] correspondingKutiButtons = new EKutiButton[7]
    {
        EKutiButton.Menu, EKutiButton.P1Left, EKutiButton.P1Right, EKutiButton.P1Up, EKutiButton.P2Left,
        EKutiButton.P2Right, EKutiButton.P2Up
    };

    [SerializeField] private static string path = "sys/class/gpio/gpio";

    private static Dictionary<EKutiButton, FileStream> fileStreams = new Dictionary<EKutiButton, FileStream>();

    private static bool p1LeftDown = false;
    private static bool p1RightDown = false;
    private static bool p1UpDown = false;
    private static bool p2LeftDown = false;
    private static bool p2RightDown = false;
    private static bool p2UpDown = false;
    private static bool menuDown = false;
    /* void Start()
     {
         InitializeFileStreams();
     }*/
    /*private KutiInput()
    {
        InitializeFileStreams();
    }*/

    void InitializeFileStreams()
    {
        for (int i = 0; i < gpioPorts.Length; i++)
        {
            FileStream temp = null;
            try
            {
                temp = new FileStream(path + gpioPorts[i] + "/value", FileMode.Open, FileAccess.Read);
                fileStreams.Add(correspondingKutiButtons[i], temp);
            }
            catch (Exception e)
            {
                Console.Write(
                    "Wasn't able to open StreamReader for KutiButton " + correspondingKutiButtons[i] +
                    " and its GPIO port " + gpioPorts[i], e);
            }
        }
    }


    public bool GetButton(EKutiButton button)
    {
        try
        {
            return ReadStream(fileStreams[button]) == 48;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return false;
    }

    public bool GetButtonDown(EKutiButton button)
    {
        bool input = false;
        try
        {
        	input = ReadStream(fileStreams[button]) == 48;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        switch (button)
        {
            case EKutiButton.Menu:
                if (input != menuDown)
                {
                    menuDown = input;
                    if (menuDown)
                        return menuDown;
                }
                break;
            case EKutiButton.P1Left:
                if (input != p1LeftDown)
                {
                    p1LeftDown = input;
                    if (p1LeftDown)
                        return p1LeftDown;
                }
                break;
            case EKutiButton.P1Right:
                if (input != p1RightDown)
                {
                    p1RightDown = input;
                    if (p1RightDown)
                        return p1RightDown;
                }
                break;
            case EKutiButton.P1Up:
                if (input != p1UpDown)
                {
                    p1UpDown = input;
                    if (p1UpDown)
                        return p1UpDown;
                }
                break;
            case EKutiButton.P2Right:
                if (input != p2RightDown)
                {
                    p2RightDown = input;
                    if (p2RightDown)
                        return p2RightDown;
                }
                break;
            case EKutiButton.P2Left:
                if (input != p2LeftDown)
                {
                    p2LeftDown = input;
                    if (p2LeftDown)
                        return p2LeftDown;
                }
                break;
            case EKutiButton.P2Up:
                if (input != p2UpDown)
                {
                    p2UpDown = input;
                    if (p2UpDown)
                        return p2UpDown;
                }
                break;
        }
        return false;
    }

/*
                //Bessere Implementation finden... so ist das schei�e
                public static int GetAxis(EKutiAxis axis)
                {
                    int input = 0;
                    switch (axis)
                    {
                        case EKutiAxis.P1AxisVertical:
                            if (Input(EKutiButton.P1Left) && Input(EKutiButton.P1Right))
                            {
                                input = 0;
                            }
                            else if (Input(EKutiButton.P1Left))
                            {
                                input = -1;
                            }
                            else if (Input(EKutiButton.P1Right))
                            {
                                input = 1;
                            }                
                        break;
                        case EKutiAxis.P2AxisVertical:
            
                        break;
                    }
                    return input;
                }*/

    private int ReadStream(FileStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        int temp = stream.ReadByte();
        return temp;
    }

    /* #region CloseStreams
 
     void CloseStreams()
     {
         if (fileStreams.Count != 0)
         {
             foreach (KeyValuePair<EKutiButton, FileStream> entry in fileStreams)
             {
                 entry.Value.Close();
             }
         }
     }
 
     void OnDestroy()
     {
         CloseStreams();
     }
 
     void OnApplicationQuit()
     {
         CloseStreams();
     }
 
     #endregion*/
}
