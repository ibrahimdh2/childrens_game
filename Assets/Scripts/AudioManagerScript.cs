using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource mainAudioSource;

    public void PlayAudio(int audioIndex)
    {
        mainAudioSource.clip = audioClips[audioIndex];
        mainAudioSource.Play();
    }
    
}
