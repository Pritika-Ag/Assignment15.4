using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using TMPro;
using UnityEngine;

public class MidiInput : MonoBehaviour
{
    private static IInputDevice _inputDevice;
    [SerializeField] private TMP_Text _played;

    private void Start()
    {
        InitializeInputDevice();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Releasing playback and device...");

        if (_inputDevice != null)
            _inputDevice.Dispose();

        Debug.Log("Playback and device released.");
    }

    private void InitializeInputDevice()
    {
        Debug.Log(_played.text);
        if (InputDevice.GetDevicesCount() > 0)
        {
            _inputDevice = InputDevice.GetByIndex(0);
            Debug.Log($"Initializing input device ...");
        }
        else
        {
            Debug.Log($"There is no input device presented in the system.");
            return;
        }

        _inputDevice.StartEventsListening();
        _inputDevice.EventReceived += OnEventReceived;

        Debug.Log("The device is listening: " + _inputDevice.IsListeningForEvents.ToString());
    }

    private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
    {
        //Debug.Log(e.Event.ToString());
        string instrumentName = getInstrumentName(e.Event.ToString());

        if (instrumentName != null)
        {
            Debug.Log(instrumentName);
            _played.text = _played.text + " " + instrumentName;
        }
    }

    string getInstrumentName(string e) {
        string instrumentCode = getBetween(e, "(", ",");
        if (instrumentCode != null && e.Contains("Note On"))
        {
            switch(instrumentCode)
            {
                case "46":
                    return "Hi-Hat";
                case "49":
                    return "Crash";
                case "38":
                    return "Snare";
                case "36":
                    return "Bass";
                default:
                    return "Other";

            }
        }

        return null;
    }

    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return null;
    }

}