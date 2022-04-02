using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPADeviceSettings : MonoBehaviour
{
    public Text GridVoltageText;
    public string VoltageString;
    public Slider VoltageSlider;

    public float voltage = 50;

    public IonRetardingGrid IRG;

    // Start is called before the first frame update
    void Start()
    {
        VoltageString = "Grid Voltage: " + voltage + "%";
        GridVoltageText.text = VoltageString;
    }

    // Update is called once per frame
    void Update()
    {
        VoltageString = "Grid Voltage: " + voltage + "%";
        GridVoltageText.text = VoltageString;
    }

    public void UpdateVoltage()
    {
        VoltageString = "Grid Voltage: " + voltage + "%";
        GridVoltageText.text = VoltageString;

        voltage = VoltageSlider.value;

        IRG.UpdateVoltage(voltage);
    }
}
