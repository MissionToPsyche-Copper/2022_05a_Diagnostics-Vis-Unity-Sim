using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownElectron : MonoBehaviour
{
    GameObject RPACenter;

    public bool outsideRPA = true;

    // Start is called before the first frame update
    void Start()
    {
        RPACenter = GameObject.FindGameObjectWithTag("RPACenter");
        Destroy(this.gameObject, 8f);

        Vector3 diff = RPACenter.transform.position - this.transform.position;
        diff.Normalize();
        GetComponent<Rigidbody>().AddRelativeForce(diff * 200f);
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRPA)
        {
            float step = 1f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, RPACenter.transform.position, step);
        }
    }

    private void FixedUpdate()
    {
        if (outsideRPA)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.layer == 11)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 17 && outsideRPA)
        {
            outsideRPA = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(1, GetComponent<Rigidbody>().velocity.y).normalized * 150f);
        }
    }
}
