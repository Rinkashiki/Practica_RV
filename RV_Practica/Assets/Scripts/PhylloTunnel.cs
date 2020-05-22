using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhylloTunnel : MonoBehaviour
{
    public Transform _tunnel;
    public AudioPeer _audioPeer;
    public float _tunnelSpeed, _cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _tunnel.position = new Vector3(_tunnel.position.x, _tunnel.position.y, _tunnel.position.z + (-_audioPeer._Amplitude / 20) * _tunnelSpeed);
        transform.position = new Vector3(transform.position.x, transform.position.y, _tunnel.position.z + _cameraDistance);
    }
}
