using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Score.puntaje += 10;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

    }
}
