using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonRetardingGrid : MonoBehaviour
{
    public float IRGVoltage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateVoltage(float newVoltage)
    {
        this.IRGVoltage = newVoltage;
    }

    public bool PassCheck(float ionCharge, float ionMass, float elementalCharge, float ionVelocity)
    {
        Debug.Log("Charge: " + ionCharge + " | Mass: " + ionMass + " | Elemental Charge: " + elementalCharge + " | Voltage: " + this.IRGVoltage);
        Debug.Log((Mathf.Sqrt((2 * ionCharge * elementalCharge * IRGVoltage) / (ionMass))));
        float criticalvelocity = Mathf.Sqrt((2 * ionCharge * elementalCharge * IRGVoltage) /(ionMass));


        Debug.Log("Crit: " + criticalvelocity + " | Ion Vel: " + ionVelocity);
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
