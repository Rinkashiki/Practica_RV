using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    public AudioPeer _audioPeer;

    float elapsedTime = 0.0f;
    float beatTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (_audioPeer._Amplitude * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        if (!_useBuffer)
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            if (elapsedTime >= beatTime)
            {
                transform.localScale = new Vector3((-_audioPeer._Amplitude * _scaleMultiplier) + _startScale, (-_audioPeer._Amplitude * _scaleMultiplier)
                                                    + _startScale, (-_audioPeer._Amplitude * _scaleMultiplier) + _startScale);
                elapsedTime = 0.0f;
            }
        }
    }
    
}
