using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    private bool zoom = false;
    [SerializeField] private Camera main;
    [SerializeField] private Text zoomButton;
    [SerializeField] private GameObject diagnostic;
    [SerializeField] private float defaultZoomHeight = 10;
    public void Zoom()
    {
        if(zoom) // zoomed in, so un zoom
        {
            main.transform.position = new Vector3(1.5f, 0, -10f);
            main.orthographicSize = defaultZoomHeight;
            zoom = false;
            zoomButton.text = "Focus on Device";
        }
        else // un zoomed, so zoom in
        {
            main.transform.Translate(diagnostic.transform.position - new Vector3(0, 0, 0));
            main.orthographicSize = 3;
            zoom = true;
            zoomButton.text = "Unfocus";
        }
    }

    public void Update()
    {
        if(zoom)
        {
            Vector3 camPos = main.transform.position;
            main.transform.Translate(diagnostic.transform.position - new Vector3(camPos.x, camPos.y, 0));
        }
    }

}
