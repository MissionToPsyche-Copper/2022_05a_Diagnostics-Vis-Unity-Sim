using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    GameObject CirclePosition;
    public GameObject OrbitCenter;

    float speed;

    bool Orbitting = false;

    // Start is called before the first frame update
    void Start()
    {
        CirclePosition = GameObject.FindGameObjectWithTag("HETCenter");

        speed = Random.Range(150f, 200f);

        GetComponent<Rigidbody>().AddForce(new Vector3(1, 0).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Orbitting)
        {
            float step = 4.4f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, CirclePosition.transform.position, step);
        }
        else
        {
            transform.RotateAround(OrbitCenter.transform.position, OrbitCenter.transform.forward, 10f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.tag == "Xenon" && !OrbitCenter)
        {
            //OrbitCenter = collision.gameObject;
            //Orbitting = true;

            //this.gameObject.transform.SetParent(collision.transform);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.layer == 11)
            Destroy(this.gameObject);
    }
}
