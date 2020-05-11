using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{

    Vector3 target = new Vector3();

    public Vector3 getTarget()
    {
        return target;
    }

    public void setTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
