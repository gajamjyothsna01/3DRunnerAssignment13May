using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents: MonoBehaviour
{
     AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayerSound()
    {
       audioSource.Play();
    }
}
