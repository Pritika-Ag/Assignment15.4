using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _played;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessKeyboardInput();
    }

    public void ProcessKeyboardInput()
    {
        /*if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            PlayCrash();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            PlayHiHat();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            PlayBass();
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            PlaySnare();
        }*/
    }

    public void PlayCrash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Crash";
            Debug.Log("Crash ");
        }
    }

    public void PlayHiHat(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Hi-hat";
            Debug.Log("Hi-Hat");
        }
    }

    public void PlaySnare(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Snare";
            Debug.Log("Snare");
        }
    }

    public void PlayBass(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Bass";
            Debug.Log("Bass");
        }
    }
}
