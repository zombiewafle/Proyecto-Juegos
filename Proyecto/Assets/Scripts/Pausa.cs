using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject gameOverText, restartButton, menuButton;
    public static bool pausa;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        Time.timeScale = 1;
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = !pausa;



            if (pausa)
            {

                Resume();

            }
            else if (!pausa)
            {
                Pause();

            }
        }  

    }

    void Resume()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    void Pause()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        menuButton.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }
}
