using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleElementHighlight : MonoBehaviour
{
    public GameObject[] siblings;
    MeshRenderer meshRenderer;

    Color StartingColor;

    // Start is called before the first frame update
    void Awake()
    {
        siblings = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        meshRenderer = this.GetComponent<MeshRenderer>();
        StartingColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        siblings = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
    }

    private void OnMouseOver()
    {
        for(int i = 0; i < siblings.Length; i++)
        {
            siblings[i].GetComponent<MultipleElementHighlight>().EnableOutline();
        }
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {
        for (int i = 0; i < siblings.Length; i++)
        {
            siblings[i].GetComponent<MultipleElementHighlight>().DisableOutline();
        }
    }

    public void EnableOutline()
    {
        meshRenderer.material.color = Color.yellow;
    }

    public void DisableOutline()
    {
        meshRenderer.material.color = StartingColor;
    }

    public void UpdateColor()
    {
        StartingColor = meshRenderer.material.color;
    }
}
