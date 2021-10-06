using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// –≈œ¢µØ¥∞¿‡
/// </summary>
public class MessageBox : MonoBehaviour
{

    public GameObject infoMessageBoxObj;
    public GameObject successMessageBoxObj;
    public GameObject errorMessageBoxObj;
    public GameObject warningMessageBoxObj;



    private static GameObject infoMessagebox;
    private static GameObject errorMessagebox;
    private static GameObject successMessagebox;
    private static GameObject warringMessagebox;

    public void InitMessageBox()
    {

        infoMessagebox = infoMessageBoxObj;
    }

    public static void Info()
    {
        
    }

    public static void Warning()
    {

    }

    public static void Success()
    {

    }

    public static void Error()
    {

    }
}
