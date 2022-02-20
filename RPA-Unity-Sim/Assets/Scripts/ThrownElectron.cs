using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThrownElectron : MonoBehaviour
{
    GameObject RPACenter;

    public bool outsideDevice = true;
    bool captured = false;

    public ElectronSuppressionGrid ESG;

    // Start is called before the first frame update
    void Start()
    {
        RPACenter = GameObject.FindGameObjectWithTag("RPACenter");


        if (SceneManager.GetActiveScene().name == "rpa")
        {
            ESG = GameObject.FindGameObjectWithTag("Electron Suppression Grid").GetComponent<ElectronSuppressionGrid>();
        }
        
        Vector3 diff = RPACenter.transform.position - this.transform.position;
        diff.Normalize();
        GetComponent<Rigidbody>().AddRelativeForce(diff * 200f);
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

            // Chance to get stuck to the ESG
            int randomChance = Random.Range(0, 101);
            if (randomChance > 77)
            {
                this.gameObject.layer = 23;
            }
            else
            {
                Destroy(this.gameObject, 3f);
            }
        }

        if (other.gameObject.layer == 20 && outsideDevice)
        {
            outsideDevice = false;
        }

        // Electron gets caught in the suppression grid
        if(other.gameObject.layer == 24)
        {
            //Debug.Log("Captured");
            captured = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            ESG.CatchElectron(this.gameObject.GetComponent<ThrownElectron>());
        }
    }

    public void ExpelFromRPA()
    {
        captured = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        float YDirection = Random.Range(-1f, 1f);
        GetComponent<Rigidbody>().AddForce(new Vector3(-1, YDirection).normalized * 175f);
        Destroy(this.gameObject, 1f);
    }
}
