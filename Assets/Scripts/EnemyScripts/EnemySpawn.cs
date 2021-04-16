using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    float startTime, endTime;

    public GameObject enemy;
    GameObject newEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) startTime = Time.time;
        if (Input.GetKeyDown(KeyCode.P)) endTime = Time.time;
        if (endTime - startTime > 1f)
        {
            newEnemy = Instantiate(enemy, transform);
            startTime = 0;
        }
    }
}
