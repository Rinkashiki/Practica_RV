using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    public AudioPeer _audioPeer;
    private Material _trailMat;
    //public Color _trailColor;

    public float _degree, _scale;
    public int _numberStart;
    public int _stepSize;
    public int _maxIteration;

    //Lerping
    public bool _useLerping;
    private bool _isLerping;
    private Vector3 _startPosition, _endPosition;
    private float _lerpPosTimer, _lerpPosSpeed;
    public Vector2 _lerpPosSpeedMinMax;
    public AnimationCurve _lerpPosAnimCurve;
    //public int _lerpPosBand;


    private int _number;
    private int _currentIteration;
    private TrailRenderer _trailRenderer;
 
    private Vector2 phyllotaxisPos;

    //Scaling
    public bool _useScaleAnimation, _useScaleCurve;
    public Vector2 _scaleAnimMinMax;
    public AnimationCurve _scaleAnimCurve;
    public float _scaleAnimSpeed;
    //public int _scaleBand;
    private float _scaleTimer, _currentScale;

    // Start is called before the first frame update
    void Awake()
    {
        _currentScale = _scale;
        _trailRenderer = GetComponent<TrailRenderer>();
        //_trailMat = new Material(_trailRenderer.material);
        //_trailMat.SetColor("_TintColor", _trailColor);
        //_trailRenderer.material = _trailMat;
        _number = _numberStart;
        transform.localPosition = PhyllotaxisCompute(_degree, _currentScale, _number);
        if (_useLerping)
        {
            _isLerping = true;
            SetLerpPositions();
        }
    }

    private void Update()
    {
        if (_useScaleAnimation)
        {
            if (_useScaleCurve)
            {
                _scaleTimer += (_scaleAnimSpeed * -_audioPeer._Amplitude / 10) * Time.deltaTime;
                if(_scaleTimer >= 1)
                {
                    _scaleTimer = -1;
                }
                _currentScale = Mathf.Lerp(_scaleAnimMinMax.x, _scaleAnimMinMax.y, _scaleAnimCurve.Evaluate(_scaleTimer));
            }
            else
            {
                _currentScale = Mathf.Lerp(_scaleAnimMinMax.x, _scaleAnimMinMax.y,  -_audioPeer._Amplitude/10);
            }
        }

        if (_useLerping)
        {
            if (_isLerping)
            {
                _lerpPosSpeed = Mathf.Lerp(_lerpPosSpeedMinMax.x, _lerpPosSpeedMinMax.y, _lerpPosAnimCurve.Evaluate(-_audioPeer._Amplitude/10));
                //_lerpPosSpeed = 5;
                //Debug.Log(-_audioPeer._Amplitude);
                //Debug.Log(_lerpPosSpeed);
                _lerpPosTimer += Time.deltaTime * _lerpPosSpeed;
                //Debug.Log(_lerpPosTimer);
                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition,Mathf.Clamp01(_lerpPosTimer));
                if(_lerpPosTimer >= 1)
                {
                    _lerpPosTimer -= 1;
                    _number += _stepSize;
                    _currentIteration++;
                    SetLerpPositions();
                }
            }

        }
        else
        {
            phyllotaxisPos = PhyllotaxisCompute(_degree, _currentScale, _number);
            transform.localPosition = new Vector3(phyllotaxisPos.x, phyllotaxisPos.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }
    }

    /*
    private void FixedUpdate()
    {
        if (_useLerping)
        {
            if (_isLerping)
            {
                float timeSinceStarted = Time.time - _timeStartedLerping;
                float percentageComplete = timeSinceStarted / _intervalLerp;
                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
                if(percentageComplete >= 0.97)
                {
                    transform.localPosition = _endPosition;
                    _number += _stepSize;
                    _currentIteration++;
                    if(_currentIteration <= _maxIteration)
                    {
                        Startlerping();
                    }
                    else
                    {
                        _isLerping = false;
                    }
                }
            }

        }
        else
        {
            phyllotaxisPos = PhyllotaxisCompute(_degree, _scale, _number);
            transform.localPosition = new Vector3(phyllotaxisPos.x, phyllotaxisPos.y, 0);
            _number+= _stepSize;
            _currentIteration++;
        }
    }
    */

    void SetLerpPositions()
    {
        phyllotaxisPos = PhyllotaxisCompute(_degree, _currentScale, _number);
        _startPosition = transform.localPosition;
        _endPosition = new Vector3(phyllotaxisPos.x, phyllotaxisPos.y, 0);
    }

    private Vector2 PhyllotaxisCompute(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);
        float radius = scale * Mathf.Sqrt(number);
        float x = radius * (float)System.Math.Cos(angle);
        float y = radius * (float)System.Math.Sin(angle);
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }

}
