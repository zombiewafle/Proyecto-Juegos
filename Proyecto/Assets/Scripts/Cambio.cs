using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PasarScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void RageQuit()
    {
        Application.Quit();
    }
}
