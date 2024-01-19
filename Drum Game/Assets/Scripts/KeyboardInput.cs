using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _played;
    [SerializeField] private AudioClip snareClip;
    [SerializeField] private AudioClip crashClip;
    [SerializeField] private AudioClip bassClip;
    [SerializeField] private AudioClip HiHatClosedClip;
    [SerializeField] private float volume = 2f;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        if(source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCrash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Crash";
            Debug.Log("Crash ");
            source.PlayOneShot(crashClip, volume);
        }
    }

    public void PlayHiHat(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Hi-hat";
            Debug.Log("Hi-Hat");
            source.PlayOneShot(HiHatClosedClip, volume);
        }
    }

    public void PlaySnare(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Snare";
            Debug.Log("Snare");
            source.PlayOneShot(snareClip, volume*2);
        }
    }

    public void PlayBass(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _played.text = _played.text + " Bass";
            Debug.Log("Bass");
            source.PlayOneShot(bassClip, volume*2);
        }
    }
}
