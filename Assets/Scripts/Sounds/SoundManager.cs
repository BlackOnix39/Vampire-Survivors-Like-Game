using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sound;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySounds(AudioClip clip, bool destroyed)
    {
        if(destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position);
        else
            audioSrc.PlayOneShot(clip);
    }
}
