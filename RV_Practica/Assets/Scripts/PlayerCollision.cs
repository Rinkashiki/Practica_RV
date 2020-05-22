using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Slider hpBar;
    public int playerHp;

    float inmmuneTime;
    GameManager manager;
    public int currentHp;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        inmmuneTime = 0.0f;
        currentHp = playerHp;
        hpBar.value = 1.0f;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && inmmuneTime <= 0.0f)
        {
            currentHp--;
            hpBar.value = (float)currentHp / playerHp;
            inmmuneTime = 1.0f;
            if (currentHp == 0)
            {
                manager.GameOver();
            }
        }
    }

    void Update()
    {
        inmmuneTime -= inmmuneTime > 0.0f ? Time.deltaTime : 0.0f;
    }
}
