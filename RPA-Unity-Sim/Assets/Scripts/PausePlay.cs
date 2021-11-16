using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{

    public bool running = true;
    public Text PauseButtonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSimulationPlay()
    {
        if (running)
        {
            PauseSim();
        }
        else
        {
            PlaySim();
        }
    }

    void PauseSim()
    {
        running = false;
        Time.timeScale = 0;
        PauseButtonText.text = "Play";
    }

    void PlaySim()
    {
        running = true;
        Time.timeScale = 1;
        PauseButtonText.text = "Pause";
    }
}
