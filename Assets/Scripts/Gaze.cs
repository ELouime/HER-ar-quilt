using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gaze : MonoBehaviour
{  
    List<SoundPlayer> infos = new List<SoundPlayer>();
    
    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<SoundPlayer>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
