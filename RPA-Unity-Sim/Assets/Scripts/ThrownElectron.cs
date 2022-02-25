using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrownElectron : MonoBehaviour
{
    GameObject RPACenter;

    public bool outsideDevice = true;


    // Start is called before the first frame update
    void Start()
    {
        RPACenter = GameObject.FindGameObjectWithTag("RPACenter");
        
        Vector3 diff = RPACenter.transform.position - this.transform.position;
        diff.Normalize();
        GetComponent<Rigidbody>().AddRelativeForce(diff * 200f);

        Destroy(this.gameObject, 15f); // destroy after set time to clear scene for other entities
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (outsideDevice)
        {
            float step = 1f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, RPACenter.transform.position, step);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // thruster
        if (collision.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }

        // outer rpa device
        if(collision.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }

        // boundaries
        if (collision.gameObject.layer == 11)
            Destroy(this.gameObject);

        // outer faraday device
        if (collision.gameObject.layer == 21)
        {
            Destroy(this.gameObject);
        }

        // faraday collector 
        if (collision.gameObject.layer == 22)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 17 && outsideDevice)
        {
            outsideDevice = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(1, GetComponent<Rigidbody>().velocity.y).normalized * 150f);

            Destroy(this.gameObject, 2f); // destroy after rebounding out of rpa
        }

        if (other.gameObject.layer == 20 && outsideDevice)
        {
            outsideDevice = false;
        }
    }
}
