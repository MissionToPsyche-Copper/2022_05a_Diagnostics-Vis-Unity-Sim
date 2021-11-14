using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xenon : MonoBehaviour
{

    float YDirection;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        YDirection = Random.Range(-1, 2);
        speed = Random.Range(150f, 200f);

        GetComponent<Rigidbody>().AddForce(new Vector3(1, YDirection).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }
    }
}
