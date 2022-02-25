using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedElectron : MonoBehaviour
{
    bool captured = false;

    public ElectronSuppressionGrid ESG;

    // Start is called before the first frame update
    void Start()
    {
        ESG = GameObject.FindGameObjectWithTag("Electron Suppression Grid").GetComponent<ElectronSuppressionGrid>();

        captured = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        float YDirection = Random.Range(-1f, 1f);
        GetComponent<Rigidbody>().AddForce(new Vector3(-1, YDirection).normalized * 175f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Electron gets caught in the suppression grid
        if (other.gameObject.layer == 24)
        {
            //Debug.Log("Captured");
            captured = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            ESG.CatchElectron(this.gameObject.GetComponent<CapturedElectron>());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // made it to collector
        if (collision.gameObject.layer == 16)
        {
            Destroy(this.gameObject);
        }
    }

    public void ExpelFromRPA()
    {
        captured = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        float YDirection = Random.Range(-1f, 1f);
        GetComponent<Rigidbody>().AddForce(new Vector3(1, YDirection).normalized * 175f);
        Destroy(this.gameObject, 1f);
    }
}
