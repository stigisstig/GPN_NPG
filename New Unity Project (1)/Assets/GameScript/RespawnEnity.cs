using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnity : MonoBehaviour
{
    public GameObject projectile;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        projectile.transform.position = transform.position;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {

        //Instantiate(projectile, transform.position, transform.rotation);
        /* projectile.transform.position = transform.position + Camera.main.transform.right * 3; //transform.position = position of player
         projectile.GetComponent<Rigidbody>().AddForce(0, 0, 1);*/ //Rigidbody 


        projectile.transform.position = transform.position;
        Debug.Log("Spawned ball");
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

    }
}
