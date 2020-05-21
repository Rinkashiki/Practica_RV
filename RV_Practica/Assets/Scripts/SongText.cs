using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongText : MonoBehaviour
{
    TextMeshPro textMesh;
    public AudioClip song;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
        textMesh.text = song.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
