using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource _audio;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            _audio.volume = 1;
        }
    }
    void Update()
    {
        _audio.volume = PlayerPrefs.GetFloat("volume");
    }
}
