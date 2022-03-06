using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text SliderText;
    public string SpeedText;
    public Slider TimeSlider;

    public float timeSpeed = 0.75f;


    // Start is called before the first frame update
    void Start()
    {
        SpeedText = timeSpeed + "x Speed";
        SliderText.text = SpeedText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSpeed()
    {
        SpeedText = TimeSlider.value + "x Speed";
        SliderText.text = SpeedText;

        timeSpeed = TimeSlider.value;
        Time.timeScale = timeSpeed;
    }
}
