using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    public int health;
    public float speed;
    public bool ataque;
    public bool muerte;
    public Animator animator;

    public GameObject gameOverText, restartButton, menuButton;

    // Start is called before the first frame update
    void Start()
    {
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (health <= 0)
        {
            Destroy(gameObject);
        }
       

        
    }

    public void TakeDamage(int damage)
    {
      
        health -= damage;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            ataque = true;
          
            if (ataque == true)
            {
                
                //animator.SetBool("ninja", true);
                //other.gameObject.SetActive(false);
                //Personaje.Instance.muerte = true;

                

            }
        }







    }

   
}
