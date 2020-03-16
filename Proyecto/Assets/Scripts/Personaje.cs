using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Personaje : MonoBehaviour
{
    public Animator animator;
    public float velMax = 5f;
    bool derecha = true;
    public float velSalto = 5f;
    public bool ataque = false;
    public int counter = 3;

    public bool muerte;

    

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask whatIsEnemies;
    public int damage;

    private bool enSuelo;
    public Transform groundCheck;
    public float checkRadio;
    public LayerMask whatisGround;
    private int extra;
    public int extraVal;
    float MovHor = 0f;

    

    public static Personaje Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

        extra = extraVal;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                animator.SetBool("Ataque", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                  
                    enemiesToDamage[i].GetComponent<VidaEnemigo>().TakeDamage(damage);
                }
            }
            else
            {
                animator.SetBool("Ataque", false);
            }
            timeBtwAttack = startTimeBtwAttack;
        }

        

        else
        {
            timeBtwAttack -= Time.deltaTime;
            
        }

        

        if (enSuelo == true)
        {
            animator.SetBool("Jump", false);
            extra = extraVal;
        }
        if (Input.GetKey(KeyCode.W) && extra > 0)
        {
            animator.SetBool("Jump", true);
            rb.velocity = Vector2.up * velSalto;
            extra--;

        }
        else if (Input.GetKeyDown(KeyCode.W) && extra == 0 && enSuelo == true)
        {

            animator.SetBool("Jump", true);
            rb.velocity = Vector2.up * velSalto;
        }



        

    }

    private void FixedUpdate()
    {
        
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, checkRadio, whatisGround);

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * velMax, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !derecha)
            Volteo();

        else if (move < 0 && derecha)
            Volteo();
    }
   
    private void Volteo()
    {
        derecha = !derecha;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        if (ataque == false)
        {

            Destroy(gameObject);
            
        }else if (muerte == true)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY,1));
   }
}
