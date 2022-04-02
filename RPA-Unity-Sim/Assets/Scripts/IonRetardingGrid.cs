using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonRetardingGrid : MonoBehaviour
{
    private float IRGVoltage = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVoltage(float newVoltage)
    {
        this.IRGVoltage = newVoltage / 100;
        //Debug.Log("Voltage = " + IRGVoltage);
    }

    public bool PassCheck(float ionCharge, float ionMass, float elementalCharge, float ionVelocity)
    {
        //Debug.Log("Charge: " + ionCharge + " | Mass: " + ionMass + " | Elemental Charge: " + elementalCharge + " | Voltage: " + this.IRGVoltage);
        //Debug.Log((Mathf.Sqrt((2 * ionCharge * elementalCharge * IRGVoltage) / (ionMass))));

        //float criticalvelocity = Mathf.Sqrt((2 * ionCharge * elementalCharge * IRGVoltage) /(ionMass));
        float criticalvelocity = IRGVoltage; // debug


        //Debug.Log("Crit: " + criticalvelocity + " | Ion Vel: " + ionVelocity);
        if(ionVelocity > criticalvelocity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
