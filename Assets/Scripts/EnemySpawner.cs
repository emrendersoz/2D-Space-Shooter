using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    public float maxY = 4.3f, minY = -4.3f;
    public GameObject[] asteroids;
    public GameObject enemy;
    public GameObject boss1;
    public float timer = 2f;
    public float counter = 0f;
    private void Start()
    {
        Invoke("enemySpawn", timer);
        
    }
    void enemySpawn()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;
        if (counter == 1)
        {
            Instantiate(boss1, temp, Quaternion.identity);

        }
        else { 
            if (Random.Range(0, 2) > 0)
            {
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], temp, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, temp, Quaternion.Euler(0f, 0f, 90f));
            }
            counter++;
            Invoke("enemySpawn", timer);
        }

    }
}
