using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

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
    public bool placed;

    private Vector3 pos;
    

    public GameObject quilt;

    // Start is called before the first frame update
    void Start()
    {
        placed = false;
        Invoke("placeSquares()",5);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    // Initial placement of all quilt squares
    private void placeSquares()
    {
        int squareCount = 0;
        int quiltDim = (int)Mathf.Sqrt(faces.Length);
        for (int i = 0; i < quiltDim && squareCount < faces.Length; i++)
        {
            for (int j = 0; j < quiltDim && squareCount < faces.Length; j++)
            {
                GameObject hold = Instantiate(quiltPrefabs, pos, quilt.transform.rotation, quilt.transform);
                
                AudioSource soundSource = hold.AddComponent<AudioSource>();
                soundSource.clip  = sounds[squareCount];
                MeshRenderer texture = hold.GetComponent<MeshRenderer>();
                texture.material = faces[squareCount];

                squareCount++;
                pos.x += .15f;
            }
            pos.z += .15f;
            pos.x = 0f;
        }
        placed = true;
    }

    private void placeSquaresSpiral()
    {
        int squareCount = 0;
        for (int i = 0; i<faces.Length; i++)
        {
            pos.x += Mathf.Sin((Mathf.PI / 2)*(Mathf.Sqrt(4 * (i + 1) - 3)));
            pos.z += Mathf.Cos((Mathf.PI / 2)*(Mathf.Sqrt(4 * (i + 1) - 3)));

            GameObject hold = Instantiate(quiltPrefabs, pos, quilt.transform.rotation, quilt.transform);

            AudioSource soundSource = hold.AddComponent<AudioSource>();
            soundSource.clip = sounds[squareCount];
            MeshRenderer texture = hold.GetComponent<MeshRenderer>();
            texture.material = faces[squareCount];

            squareCount++;
        }
        placed = true;
    }
}
