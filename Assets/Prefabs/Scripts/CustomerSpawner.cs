using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{

    public GameObject customerObj;
    public GameObject spawnPoint;
    public int randomGen;


    // Start is called before the first frame update
   public void StartSpawn()
    {
        
            randomGen = Random.Range(4, 11);

        for (int i = 0; i < randomGen; i++)
        {
            Instantiate(customerObj, spawnPoint.transform.parent);
            customerObj.transform.position = spawnPoint.transform.position;
        }
    }
   

   
}
