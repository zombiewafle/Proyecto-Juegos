using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextspawn = 0f;
    public bool spawnear = true;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnear = true;
        Personaje.Instance.muerte = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (Time.time > nextspawn)
            {
                nextspawn = Time.time + spawnRate;
                randX = Random.Range(-19.2f, 19.2f);
                whereToSpawn = new Vector2(transform.position.x, randX);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
                spawnear = true;

            }
        
        
        
        
    }
}
