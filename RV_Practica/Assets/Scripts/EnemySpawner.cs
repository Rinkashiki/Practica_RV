using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Spawn points
    public GameObject[] spawns;
    public GameObject despawn;
    private Vector3 despawnPosition;

    // Ball speed
    public float speed = 1;

    private AudioPeer audioPeer;

    // Spawn ratio per time unit
    private float elapsedTime = 0;
    private float spawnRate = 0.25f;
    private int maxEnemies; 

    // Start is called before the first frame update
    void Start()
    {
        despawnPosition = despawn.transform.position;
        audioPeer = FindObjectOfType<AudioPeer>();
        maxEnemies = spawns.Length - 2;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        despawnPosition = despawn.transform.position;

        if (elapsedTime > spawnRate)
        {
            elapsedTime = 0;
            int count = 0;
            foreach (float band in audioPeer._freqBand)
            {
                if (band < -3.0f)
                {
                    int index = Random.Range(0, spawns.Length);
                    Vector3 spawnPoint = spawns[index].transform.position;
                    GameObject enemy = SpawnEnemy(spawnPoint, spawns[index]);
                    count++;
                }
                if (count == maxEnemies) break;
            }
        }

        MoveEnemies();
    }

    GameObject SpawnEnemy(Vector3 spawnPoint, GameObject parent)
    {
        GameObject enemyBall = Instantiate(Resources.Load<GameObject>("enemyBall"), spawnPoint, new Quaternion());
        enemyBall.transform.SetParent(parent.transform);
        return enemyBall;
    }

    void MoveEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float step = speed * Time.deltaTime;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, despawnPosition, step);

            if (Vector3.Distance(enemy.transform.position, despawnPosition) < Mathf.Epsilon)
            {
                Destroy(enemy);
            }
        }
    }
}
