using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip[] playerAudio;
    public AudioSource playerAudioSource;

    public void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }
}
