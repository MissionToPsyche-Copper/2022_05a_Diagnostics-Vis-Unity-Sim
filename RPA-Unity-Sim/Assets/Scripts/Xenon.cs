using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Xenon : MonoBehaviour
{
    GameObject RPACenter;

    float YDirection;

    float speed;

    bool isCharged = false;

    MeshRenderer meshRenderer;

    float timeSpawned;
    float timeAllowed = 2f;

    public IonRetardingGrid IRG;
    // Functions to find critical velocity
    public float ionMass = 131.293f; // atomic units
    public float ionCharge = 0; // starts uncharged
    public float elementaryCharge = 12.1299f;
    public float velocity; // ionization enery? unknown

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "rpa")
        {
            IRG = GameObject.FindGameObjectWithTag("Ion Retarding Grid").GetComponent<IonRetardingGrid>();
        }
        
        timeSpawned = Time.time;

        RPACenter = GameObject.FindGameObjectWithTag("RPACenter");
        meshRenderer = this.GetComponent<MeshRenderer>();

        YDirection = Random.Range(-1, 2);
        speed = Random.Range(150f, 200f);

        GetComponent<Rigidbody>().AddForce(new Vector3(1, YDirection).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharged)
        {
            float step = 0.75f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, RPACenter.transform.position, step);
        }
        else
        {
            // destroy if not charged and alive for too long
            if (Time.deltaTime > (timeSpawned + timeAllowed))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ion Repulsion Grid
        if(other.gameObject.layer == 14)
        {
            if(IRG.PassCheck(ionCharge, ionMass, elementaryCharge, velocity))
            {
                this.gameObject.layer = 19;
            }
            else
            {
                //Debug.LogError("Failed check");
            }
            Destroy(this.gameObject, 3f);
        }

        //Faraday Center Trigger
        if(other.gameObject.layer == 20)
        {
            isCharged = false;
            Destroy(this.gameObject, 8f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // outer RPA device
        if(collision.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }

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

        if (collision.transform.tag == "Electron" && !isCharged)
        {
            meshRenderer.material.color = Color.magenta;

            // Charge Xenon, get velocity for critical check in device
            isCharged = true;
            ionCharge = 1;
            velocity = Random.Range(0.0115f, 0.99999f);

            // Change Type
            this.gameObject.layer = 9;
            this.gameObject.tag = "Charged Xenon";

            this.GetComponent<MultipleElementHighlight>().UpdateColor();

            GetComponent<Rigidbody>().velocity = Vector3.zero;

            int positionRange = Random.Range((int)RPACenter.transform.position.y - 4, (int)RPACenter.transform.position.y + 4);

            GetComponent<Rigidbody>().AddForce((new Vector3(RPACenter.transform.position.x, positionRange) - new Vector3(this.transform.position.x, this.transform.position.y)) * 8.8f);
        }

        if(collision.gameObject.layer == 14 && !isCharged)
            Destroy(this.gameObject); // actually should bounce away

        // boundaries
        if (collision.gameObject.layer == 11)
            Destroy(this.gameObject);

        // made it to collector
        if (collision.gameObject.layer == 16)
        {
            collision.gameObject.GetComponent<RPACollector>().RepelElectron();
            Destroy(this.gameObject);
        }
            

        if(collision.gameObject.layer == 14)
        {
            Debug.Log("HIT IRA!");
        }
    }
}
