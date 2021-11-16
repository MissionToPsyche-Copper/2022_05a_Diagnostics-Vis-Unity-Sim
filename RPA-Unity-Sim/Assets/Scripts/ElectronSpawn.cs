using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSpawn : MonoBehaviour
{
    public GameObject ElectronPrefab;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.1f)
        {
            Instantiate(ElectronPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            time = 0f;
        }
    }
}
