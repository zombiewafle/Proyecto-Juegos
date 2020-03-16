using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public int vida;
    public int corazones;
    public Image[] hearts;

    public Sprite hayVida;
    public Sprite NohayVida;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(vida > corazones)
        {
            vida = corazones;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < vida)
            {
                
                hearts[i].sprite = hayVida;
            }
            else
            {
                hearts[i].sprite = NohayVida;
            }



            if(i < corazones)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
