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

    // Update is called once per frame
    void Update()
    {
        //Spawner with time
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime)
        {
            SpawnEnemyBall(new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-3.0f, 3.0f), 3.86f), player.transform.position);
            elapsedTime = 0.0f;
        }

        //Enemies position update and destroy functions
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies!= null)
        {
            MoveEnemies(enemies);
            DestroyEnemyBall(enemies);
        }

    }

    void SpawnEnemyBall(Vector3 enemyPos, Vector3 playerPos)
    {
        GameObject enemyBall = Instantiate(Resources.Load<GameObject>("enemyBall"), enemyPos, new Quaternion());
        Vector3 dir = new Vector3(playerPos.x - enemyPos.x, playerPos.y - enemyPos.y, playerPos.z - enemyPos.z).normalized;
        float dist = Vector3.Distance(enemyPos, playerPos) + 2;
        float x = enemyPos.x + dir.x * dist;
        float y = enemyPos.y + dir.y * dist;
        float z = enemyPos.z + dir.z * dist;
        Vector3 target = new Vector3(x, y, z);
        enemyBall.GetComponent<EnemyBall>().setTarget(target);
    }

    void MoveEnemies(GameObject[] enemies)
    {
        foreach(GameObject enemy in enemies) { 
            float step = speed * Time.deltaTime;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.GetComponent<EnemyBall>().getTarget(), step);
        }
    }

    void DestroyEnemyBall(GameObject[] enemies)
    {
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy.transform.position == enemy.GetComponent<EnemyBall>().getTarget())
                {
                    Destroy(enemy);
                }
            }
        }
    }
}
