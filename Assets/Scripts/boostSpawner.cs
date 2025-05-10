using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostSpawner : MonoBehaviour
{
    public Object boostPrefab;      // Holds the boost prefab to be instantiated later.

    float previousSpawn = -1000;    // The time since the last spawn.
    float nextSpawn = 10;            // The time until the next spawn.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the time subtract previous spawn is less than the time of the next spawn...
        if (Time.time - previousSpawn > nextSpawn)
        {
            // the time of the previous spawn becomes the new time...
            previousSpawn = Time.time;
            // and an item is spawned from the boost prefab.
            Instantiate(boostPrefab);
        }
    }
}
