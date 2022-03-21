using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("PopUpText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        string text = tag;
        switch(text)
        {
            case "Floating Grid": text += "\nOnly allows Xenon ions and electrons into the device"; break;
            case "Electron Repulsion Grid": text += "\nStops electrons and allows ions to pass through"; break;
            case "Ion Retarding Grid": text += "\nOnly allows ions with a high enough energy to pass through"; break;
            case "Electron Suppression Grid": text += "\nForces electrons removed from the collector to return to it"; break;
            case "Collector": text += "\nCounts the number of ions that reach it"; break;
            default: text += ""; break;
        }
        textBox.text = text;
    }

    private void OnMouseExit()
    {
        textBox.text = "";
    }
}
