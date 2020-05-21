using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //GameObject enemyBall;
    GameObject player;
    float speed = 2.0f;
    float elapsedTime = 0.0f;
    float spawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerInstance");
        //SpawnEnemyBall(new Vector3(-0.04f, 3.27f, 3.86f), player.transform.position);
        //SpawnEnemyBall(new Vector3(1.0f, 2.5f, 3.86f), player.transform.position);
        //SpawnEnemyBall(new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-3.0f, 3.0f), 3.86f), player.transform.position);
    }

    public void GameOver()
    {
        Debug.Log("End");
        // End the game
    }

}
