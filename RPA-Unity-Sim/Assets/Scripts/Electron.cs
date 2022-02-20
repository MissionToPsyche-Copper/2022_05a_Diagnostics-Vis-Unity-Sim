using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public GameObject ThrownElectronPrefab;

    public GameObject[] electronTargets;
    public GameObject TargetPosition;

    public int random;

    float speed;
    float timeLeftAlive = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        electronTargets = GameObject.FindGameObjectsWithTag("ElectronTarget");
        random = Random.Range(0, electronTargets.Length);
        TargetPosition = electronTargets[random];

        speed = Random.Range(150f, 200f);

        GetComponent<Rigidbody>().AddForce(new Vector3(1, 0).normalized * speed);

        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = 4.4f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, TargetPosition.transform.position, step);
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
            Instantiate(ThrownElectronPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject, 2f);
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
}
