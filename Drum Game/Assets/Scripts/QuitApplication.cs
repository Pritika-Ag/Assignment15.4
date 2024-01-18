using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void button_exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
