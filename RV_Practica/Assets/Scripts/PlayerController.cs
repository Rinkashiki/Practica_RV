using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerInstance");
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Rotate(new Vector3(1, 0, 0), 1);
       
    }
}
