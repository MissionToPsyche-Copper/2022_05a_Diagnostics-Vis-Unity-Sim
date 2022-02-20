using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{
    // Used to hide/show slider when game is paused
    // https://stackoverflow.com/a/36611745
    GameObject timeSlider;
    GameObject timeText;

    public bool running = true;
    public Text PauseButtonText;

    // Start is called before the first frame update
    void Start()
    {
        timeSlider = GameObject.Find("TimeSlider");
        timeText = GameObject.Find("TimeText");
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
        timeSlider.SetActive(false);
        timeText.SetActive(false);
    }

    void PlaySim()
    {
        running = true;
        Time.timeScale = 1;
        PauseButtonText.text = "Pause";
        timeSlider.SetActive(true);
        timeText.SetActive(true);
    }
}
