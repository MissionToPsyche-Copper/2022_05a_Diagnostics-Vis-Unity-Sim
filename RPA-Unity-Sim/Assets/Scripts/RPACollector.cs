using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPACollector : MonoBehaviour
{
    public GameObject[] RepelledElectronSpawns;
    public GameObject RepelledElectronPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepelElectron()
    {
        // Chance to Repell an electron
        int randomChance = Random.Range(0, 101);
        if (randomChance > 50)
        {
            int randomSpawnLocation = Random.Range(0, 3);
            Instantiate(RepelledElectronPrefab, RepelledElectronSpawns[randomSpawnLocation].transform.position, Quaternion.Euler(Vector3.zero));
            Debug.Log("Repelled an Electron");
        }
    }
}
