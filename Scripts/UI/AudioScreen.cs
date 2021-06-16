using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioScreen : MonoBehaviour
{
    private AudioManager audioManager;
    public event Action SwitchToTextCanvas;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
}
