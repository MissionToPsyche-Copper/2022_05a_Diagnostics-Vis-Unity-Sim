using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaradayMovement : MonoBehaviour
{
    bool rotating = false;
    bool up = true;

    float direction = 1;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotating)
        {
            rotating = true;
            StartCoroutine(RotateAnim());
        }
    }

    IEnumerator RotateAnim()
    {
        bool localrot = true;
        while (localrot)
        {
            this.transform.Rotate(Vector3.forward * Time.deltaTime * 10f);
            yield return null;
            if(this.transform.eulerAngles.z > 33 && this.transform.eulerAngles.z < 180)
            {
                localrot = false;
            }
        }

        localrot = true;
        while (localrot)
        {
            this.transform.Rotate(Vector3.back * Time.deltaTime * 10f);
            yield return null;
            if (this.transform.eulerAngles.z < 327 && this.transform.eulerAngles.z > 180)
            {
                localrot = false;
            }
        }

        rotating = false;
    }
}
