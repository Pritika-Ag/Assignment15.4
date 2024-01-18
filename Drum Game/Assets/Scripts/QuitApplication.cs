using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void button_exit()
    {
        /*if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        } else
        {
            Application.Quit();
        }*/
        Debug.Log("QUIT");
        Application.Quit();
    }
}
