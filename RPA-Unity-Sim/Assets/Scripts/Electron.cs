using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public GameObject ThrownElectronPrefab;

    GameObject CirclePosition;

    float speed;
    float timeLeftAlive = 5f;

    // Start is called before the first frame update
    void Start()
    {
        CirclePosition = GameObject.FindGameObjectWithTag("ElectronTarget");

        speed = Random.Range(150f, 200f);

        GetComponent<Rigidbody>().AddForce(new Vector3(1, 0).normalized * speed);

        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = 4.4f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, CirclePosition.transform.position, step);
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

        if (collision.transform.tag == "Xenon")
        {
            //OrbitCenter = collision.gameObject;
            //Orbitting = true;

            //this.gameObject.transform.SetParent(collision.transform);
            Instantiate(ThrownElectronPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject, 2f);
        }

        if(collision.gameObject.layer == 11)
            Destroy(this.gameObject);
    }
}
