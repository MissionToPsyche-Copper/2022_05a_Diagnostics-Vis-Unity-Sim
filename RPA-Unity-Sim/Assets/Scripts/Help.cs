using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject HelpPanel;

    // Start is called before the first frame update
    void Start()
    {
        HelpPanel = GameObject.Find("HelpPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHelpButtonClicked()
	{
        HelpPanel.SetActive(true);
	}

    public void OnHelpExitButtonClicked()
	{
        HelpPanel.SetActive(false);
	}
}
