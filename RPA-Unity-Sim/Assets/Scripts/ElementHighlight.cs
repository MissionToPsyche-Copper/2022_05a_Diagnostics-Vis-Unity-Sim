using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHighlight : MonoBehaviour
{
    MeshRenderer meshRenderer;

    Color StartingColor;

    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        StartingColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        meshRenderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = StartingColor;
    }
}
