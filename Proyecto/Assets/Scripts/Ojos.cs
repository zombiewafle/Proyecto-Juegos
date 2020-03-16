using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    public float VelMov = 3f;
    Transform Izq1, der1;
    Vector3 localScale;
    bool MovDer = true;
    Rigidbody2D rb;

    public bool ataque;
    public bool muerte;
    public Animator animator;
    public bool pausa;
    public float duration;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        Izq1 = GameObject.Find("Izq1").GetComponent<Transform>();
        der1 = GameObject.Find("der1").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > der1.position.x)
        {
            MovDer = false;
        }

        if (transform.position.x < Izq1.position.x)
        {
            MovDer = true;

        }

        if (MovDer)
        {
            MoverDerecha();
        }
        else
        {
            MoverIzquierda();
        }

        


    }

    

    void MoverDerecha()
    {
        MovDer = true;
        localScale.x = 0.25f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * VelMov, rb.velocity.y);

    }

    void MoverIzquierda()
    {
        MovDer = false;
        localScale.x = -0.25f;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * VelMov, rb.velocity.y);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            ataque = true;

            if (ataque == true)
            {

                animator.SetBool("ninja", true);
                other.gameObject.SetActive(false);
                Personaje.Instance.muerte = true;



            }
        }
    }
}
