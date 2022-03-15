using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPATutorialManager : MonoBehaviour
{
    public PausePlay PausePlayController;
    public Camera MainCamera;
    // UI interactables
    public Button pauseButton;
    public Button zoomButton;

    // timer
    public float timer = 0;

    // Camera Positions
    public Vector3 mainPosition;
    public Vector3 zoomPosition;

    // UI tutorial panels and variables
    [Header("Panel 1")]
    public GameObject TutorialPanel1;

    // panel 2
    [Header("Panel 2")]
    public GameObject TutorialPanel2;
    public bool runPanel2Blink = false;
    public MultipleElementHighlight HETInsulation; // store one element from group; highlight all with EnableAll()

    // panel 3
    [Header("Panel 3")]
    public GameObject TutorialPanel3;
    public bool runPanel3Blink = false;
    public MultipleElementHighlight RPAOutline;

    // panel 4
    [Header("Panel 4")]
    public GameObject TutorialPanel4;
    public bool runPanel4Blink = false;
    public ElementHighlight FloatingGrid;

    // panel 5
    [Header("Panel 5")]
    public GameObject TutorialPanel5;
    public bool runPanel5Blink = false;
    public ElementHighlight ERGrid;

    // panel 6
    [Header("Panel 6")]
    public GameObject TutorialPanel6;
    public bool runPanel6Blink = false;
    public ElementHighlight IRGrid;

    // panel 7
    [Header("Panel 7")]
    public GameObject TutorialPanel7;
    public bool runPanel7Blink = false;
    public ElementHighlight Collector;
    public ElementHighlight ESG;



    // Start is called before the first frame update
    void Start()
    {
        PausePlayController = this.gameObject.GetComponent<PausePlay>();
        PausePlayController.ToggleSimulationPlay();
        pauseButton.interactable = false;
        zoomButton.interactable = false;

        mainPosition = MainCamera.transform.position;
        zoomPosition = new Vector3(15, 1.75f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (runPanel2Blink)
        {
            if(timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel2BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
            
        }

        if (runPanel3Blink)
        {
            if (timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel3BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
        }

        if (runPanel4Blink)
        {
            if (timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel4BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
        }

        if (runPanel5Blink)
        {
            if (timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel5BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
        }

        if (runPanel6Blink)
        {
            if (timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel6BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
        }

        if (runPanel7Blink)
        {
            if (timer < Time.realtimeSinceStartup)
            {
                StartCoroutine(Panel7BlinkAnim());
                timer = Time.realtimeSinceStartup + 0.5f;
            }
        }
    }

    public void DisableTutorialLocks()
    {
        pauseButton.GetComponent<Button>().interactable = true;
        zoomButton.GetComponent<Button>().interactable = true;
    }

    // First Tutorial Panel
    public void ContinueFirstPanel()
    {
        TutorialPanel1.SetActive(false);
        TutorialPanel2.SetActive(true);
        runPanel2Blink = true;
    }

    public void SkipLessons()
    {
        TutorialPanel1.SetActive(false);

        PausePlayController.ToggleSimulationPlay();
        DisableTutorialLocks();
    }

    // Second Tutorial Panel
    public void BackSecondPanel()
    {
        TutorialPanel2.SetActive(false);
        TutorialPanel1.SetActive(true);
        runPanel2Blink = false;
    }

    IEnumerator Panel2BlinkAnim()
    {
        HETInsulation.EnableAll();
        yield return new WaitForSecondsRealtime(0.25f);
        HETInsulation.DisableAll();
    }

    public void ContinueSecondPanel()
    {
        // disable 2
        TutorialPanel2.SetActive(false);
        runPanel2Blink = false;

        // enable 3
        TutorialPanel3.SetActive(true);
        runPanel3Blink = true;
    }

    // Third Tutorial Panel
    public void BackThirdPanel()
    {
        // disable 3
        TutorialPanel3.SetActive(false);
        runPanel3Blink = false;

        // enable 2
        TutorialPanel2.SetActive(true);
        runPanel2Blink = true;
    }

    IEnumerator Panel3BlinkAnim()
    {
        RPAOutline.EnableAll();
        yield return new WaitForSecondsRealtime(0.25f);
        RPAOutline.DisableAll();
    }

    // Transition to RPA Zoom with 4th Panel
    public void ContinueThirdPanel()
    {
        // disable 3
        TutorialPanel3.SetActive(false);
        runPanel3Blink = false;

        // enable 4
        TutorialPanel4.SetActive(true);
        runPanel4Blink = true;

        // enable time
        PausePlayController.ToggleSimulationPlay();
        Time.timeScale = 0.75f;

        // Move Camera to RPA
        MainCamera.transform.position = zoomPosition;
        MainCamera.orthographicSize = 7;
    }

    // Fourth Tutorial Panel
    public void ContinueFourthPanel()
    {
        // disable 4
        runPanel4Blink = false;
        TutorialPanel4.SetActive(false);

        // enable 5
        runPanel5Blink = true;
        TutorialPanel5.SetActive(true);

        
    }

    IEnumerator Panel4BlinkAnim()
    {
        FloatingGrid.EnableOutline();
        yield return new WaitForSecondsRealtime(0.25f);
        FloatingGrid.DisableOutline();
    }

    // Fifth Tutorial Panel
    public void ContinueFifthPanel()
    {
        // disable 5
        runPanel5Blink = false;
        TutorialPanel5.SetActive(false);

        // enable 6
        runPanel6Blink = true;
        TutorialPanel6.SetActive(true);
    }

    IEnumerator Panel5BlinkAnim()
    {
        ERGrid.EnableOutline();
        yield return new WaitForSecondsRealtime(0.25f);
        ERGrid.DisableOutline();
    }

    public void BackFifthPanel()
    {
        // disable 5
        runPanel5Blink = false;
        TutorialPanel5.SetActive(false);

        // enable 4
        TutorialPanel4.SetActive(true);
        runPanel4Blink = true;
    }

    // Sixth Tutorial Panel
    public void ContinueSixthPanel()
    {
        // disable 6
        runPanel6Blink = false;
        TutorialPanel6.SetActive(false);

        // enable 7
        runPanel7Blink = true;
        TutorialPanel7.SetActive(true);
    }

    IEnumerator Panel6BlinkAnim()
    {
        IRGrid.EnableOutline();
        yield return new WaitForSecondsRealtime(0.25f);
        IRGrid.DisableOutline();
    }

    public void BackSixthPanel()
    {
        // disable 6
        runPanel6Blink = false;
        TutorialPanel6.SetActive(false);

        // enable 5
        TutorialPanel5.SetActive(true);
        runPanel5Blink = true;
    }

    // Sixth Tutorial Panel
    public void ContinueSeventhPanel()
    {
        // disable 7
        runPanel7Blink = false;
        TutorialPanel7.SetActive(false);

        DisableTutorialLocks();

        // Move Camera Back to Main Position
        MainCamera.transform.position = mainPosition;
        MainCamera.orthographicSize = 10;
    }

    IEnumerator Panel7BlinkAnim()
    {
        Collector.EnableOutline();
        ESG.EnableOutline();
        yield return new WaitForSecondsRealtime(0.25f);
        Collector.DisableOutline();
        ESG.DisableOutline();
    }

    public void BackSeventhPanel()
    {
        // disable 7
        runPanel7Blink = false;
        TutorialPanel7.SetActive(false);

        // enable 6
        TutorialPanel6.SetActive(true);
        runPanel6Blink = true;
    }
}
