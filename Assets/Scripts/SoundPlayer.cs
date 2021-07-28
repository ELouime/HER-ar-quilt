using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void playSound()
    {
        audioSource.Play();
    }

    public void stopSound()
    {
        audioSource.Stop();
    } 
}
