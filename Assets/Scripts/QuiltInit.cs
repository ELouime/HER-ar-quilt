using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiltInit : MonoBehaviour
{
    /*
     * IMPORTANT 
     * Currently a placeholder, works based off of the corner
     * for the final integration it must work off of the center
     */

    // Square prefab, submitted faces, submitted sounds
    public GameObject quiltPrefabs;
    public Material[] faces;
    public AudioClip[] sounds;
    private Vector3 pos =  Vector3.zero;

    public GameObject quilt;

    // Start is called before the first frame update
    void Start()
    {
        placeSquares();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initial placement of all quilt squares
    void placeSquares()
    {
        int squareCount = 0;
        int quiltDim = (int)Mathf.Sqrt(faces.Length);
        for (int i = 0; i < quiltDim && squareCount < faces.Length; i++)
        {
            for (int j = 0; j < quiltDim && squareCount < faces.Length; j++)
            {
                GameObject hold = Instantiate(quiltPrefabs, pos, quilt.transform.rotation, quilt.transform);
                
                AudioSource soundSource = hold.GetComponent<AudioSource>();
                soundSource.clip = sounds[squareCount];
                MeshRenderer texture = hold.GetComponent<MeshRenderer>();
                texture.material = faces[squareCount];

                squareCount++;
                pos.x += .15f;
            }
            pos.z += .15f;
            pos.x = 0f;
        }

    }
}
