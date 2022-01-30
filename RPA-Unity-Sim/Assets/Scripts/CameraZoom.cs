using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    private bool zoom = false;
    [SerializeField] private Camera main;
    [SerializeField] private Text zoomButton;
    public void Zoom()
    {
        if(zoom) // zoomed in, so un zoom
        {
            main.transform.Translate(new Vector3(-14, 0, 0));
            main.orthographicSize = 10;
            zoom = false;
            zoomButton.text = "Zoom In";
        }
        else // un zoomed, so zoom in
        {
            main.transform.Translate(new Vector3(14, 0, 0));
            main.orthographicSize = 5;
            zoom = true;
            zoomButton.text = "Zoom Out";
        }
    }

}
