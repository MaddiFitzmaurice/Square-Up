using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSFX : MonoBehaviour
{
    public AudioClip[] bossAudio;
    public AudioSource bossAudioSource;

    public void Start()
    {
        bossAudioSource = GetComponent<AudioSource>();
    }
}
