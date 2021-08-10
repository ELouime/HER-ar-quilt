using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gaze : MonoBehaviour
{  
    List<SoundPlayer> infos = new List<SoundPlayer>();
    public QuiltInit quiltInit;
    private bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        // verify all objects have been instanced before attempting to locate sound objects
        Coroutine running = StartCoroutine(findSoundObj());
    }

    // Update is called once per frame
    void Update()
    {
        // Check with each update if the quilt has been sucessfully placed
        isPlaced = quiltInit.placed;

        // Project a forward ray from the camera object, if it hits a square with an attatched sound play the sound 
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasSound") && !go.GetComponent<SoundPlayer>().audioSource.isPlaying)
            {
                PlaySounds(go.GetComponent<SoundPlayer>());
            }

        }
        
        // if LOS is broken stop playing the sound
        else
        {
            StopAll();
        }
    }

    void PlaySounds(SoundPlayer desiredSound)
    {
        foreach(SoundPlayer info in infos)
        {
            if(info == desiredSound)
            {
                info.playSound();
            }
            else
            {
                info.stopSound();
            }
        }
    }
    void StopAll()
    {
        foreach (SoundPlayer info in infos)
        {
            info.stopSound();
        }
    }

    // Adds a delay to identifying sound objects to allow for the assignment of all squares 
    // ***MAY NEED TO BE CHANGED TO BOOLEAN ARGUMENT INSTEAD OF TIME DELAY***
    IEnumerator findSoundObj()
    {
        yield return new WaitUntil(() => isPlaced == true);
        infos = FindObjectsOfType<SoundPlayer>().ToList();
    }
}
