using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSuppressionGrid : MonoBehaviour
{
    public List<ThrownElectron> CaughtElectrons;

    // Start is called before the first frame update
    void Start()
    {
        CaughtElectrons = new List<ThrownElectron>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // hit by xenon, expel some electrons
        if (other.gameObject.layer == 19)
        {
            //Debug.Log("Trigger hit");
            ExpelElectrons();
        }
    }

    public void CatchElectron(ThrownElectron currentObject)
    {
        CaughtElectrons.Add(currentObject);
    }

    public void ExpelElectrons()
    {
        int randomAmount = Random.Range(1, CaughtElectrons.Count - 1);

        if(CaughtElectrons.Count >= 1)
        {
            for(int i = 0; i < randomAmount; i++)
            {
                Debug.Log("Expelled! New Count: " + CaughtElectrons.Count);
                CaughtElectrons[CaughtElectrons.Count - 1].ExpelFromRPA();
                CaughtElectrons.RemoveAt(CaughtElectrons.Count - 1);
            }
            
        }
    }
}
