using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaradayTutorialManager : MonoBehaviour
{
    private bool zoom = false;

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

    [Header("Panel 1")]
    public GameObject TutorialPanel1;

    [Header("Panel 2")]
    public GameObject TutorialPanel2;
    public bool runPanel2Blink = false;
    public MultipleElementHighlight HETInsulation;

    [Header("Panel 3")]
    public GameObject TutorialPanel3;
    public bool runPanel3Blink = false;
    public MultipleElementHighlight FaradayOutline;

    // Start is called before the first frame update
    void Start()
    {
        PausePlayController = this.gameObject.GetComponent<PausePlay>();
        PausePlayController.ToggleSimulationPlay();
        pauseButton.interactable = false;
        zoomButton.interactable = false;

        mainPosition = MainCamera.transform.position;
        zoomPosition = new Vector3(1.5f, 0, -10f); // get this to follow the Faraday Probe???
    }

    // Update is called once per frame
    void Update()
    {
        if (runPanel2Blink)
        {
            if (timer < Time.realtimeSinceStartup)
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

        // This is basically taken from the CameraZoom.cs class
        if (zoom)
		{
            Vector3 pos = MainCamera.transform.position;
            MainCamera.transform.Translate(FaradayOutline.transform.position - new Vector3(pos.x + 2f, pos.y, 0));
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

        // enable time
        PausePlayController.ToggleSimulationPlay();
        Time.timeScale = 1f;

        // Move Camera to Faraday Probe
        MainCamera.transform.position = zoomPosition;
        MainCamera.orthographicSize = 3;
        zoom = true;
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

        // enable time
        PausePlayController.ToggleSimulationPlay();
        Time.timeScale = 0f;

        // Move Camera Back to Main Position
        MainCamera.transform.position = mainPosition;
        MainCamera.orthographicSize = 15;
        zoom = false;
    }

    IEnumerator Panel3BlinkAnim()
    {
        FaradayOutline.EnableAll();
        yield return new WaitForSecondsRealtime(0.25f);
        FaradayOutline.DisableAll();
    }

    // Transition to RPA Zoom with 4th Panel
    public void ContinueThirdPanel()
    {
        // disable 3
        TutorialPanel3.SetActive(false);
        runPanel3Blink = false;

        DisableTutorialLocks();

        // Move Camera Back to Main Position
        MainCamera.transform.position = mainPosition;
        MainCamera.orthographicSize = 15;
        zoom = false;
    }
}
