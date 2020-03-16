using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject gameOverText, restartButton, menuButton;
    public int timeLeft = 5;
    public Text countdownText;

    // Use this for initialization
    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        menuButton.SetActive(false);
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Tiempo: " + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "FELICIDADES";
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
