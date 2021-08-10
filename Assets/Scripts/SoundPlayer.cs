using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public float animationDelay = 5f;
    public Vector3 finScale = new Vector3(.1f, .005f, .1f);
    public Vector3 initScale;

    public float aniTime = 3;

    public bool soundAssigned;

    float timeElapsed = 0;

    public void Start()
    {
        //transform.localScale = Vector3.zero;
        //initScale = transform.localScale;

        audioSource = null;
        soundAssigned = false;
        Coroutine run = StartCoroutine(setAS());
    }

    public void Update()
    {
        // Becomes true when the soundplayer object has been assigned by the quilt init method
        soundAssigned = audioSource != null;


        // Intro animation to make squares appear
        //if(soundAssigned)
        //{
        //    float t = timeElapsed / aniTime;
        //    t = t * t * (3f - 2f * t);
        //
        //    transform.localScale = Vector3.Lerp(initScale, finScale, t);
        //    timeElapsed += Time.deltaTime;
        //}
        
    }

    public void playSound()
    {
        audioSource.PlayDelayed(1);
    }

    public void stopSound()
    {
        audioSource.Stop();
    }
    
    // Adds a time delay to allow the assignment of the soundplayer object before attempting to reference it 
    IEnumerator setAS()
    {
        yield return new WaitUntil(() => soundAssigned = true);
        audioSource = this.GetComponent<AudioSource>();
    }
}
