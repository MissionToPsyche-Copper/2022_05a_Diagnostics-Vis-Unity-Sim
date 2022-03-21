using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaradayOutput : MonoBehaviour
{
    public RawImage OutputDisplay;

    public float density = 0;
    float time = 0f;
    float delay = 0.1f;

    float densityDecay = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (density > 0 && time >= delay)
        {
            density -= densityDecay;
            time = 0;
        }

        OutputDisplay.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, density);
    }

    public void IncreaseDensity()
    {
        if(density <= 81)
            this.density += 18;
    }
}
