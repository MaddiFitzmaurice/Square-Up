using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUISFX : MonoBehaviour
{
    public AudioClip[] gameUIAudio;
    public AudioSource gameUIAudioSource;

    public void Start()
    {
        gameUIAudioSource = GetComponent<AudioSource>();
    }
}
