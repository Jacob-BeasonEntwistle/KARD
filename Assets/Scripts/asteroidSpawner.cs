using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public GameObject[] rockPrefab;      // Holds the list of rocks to be instantiated later.

    // Time since the previous rock spawn.
    float previousSpawn = -500f;
    // Time of the next spawn.
    float nextSpawn = 3;

    // Update is called once per frame
    void Update()
    {
        // If the time subtract previous spawn is less than the time of the next spawn...
        if (Time.time - previousSpawn > nextSpawn)
        {
            // a rock is selected using the getRock() function...
            int selected = getRock();

            // the time till next spawn is a random number between 4 and 10...
            nextSpawn = Random.Range(3, 8);
            // the time of the previous spawn becomes the new time...
            previousSpawn = Time.time;

            // and an item is spawned from the rock prefab.
            Instantiate(rockPrefab[selected]);
        }
    }

    // A get function that...
    int getRock()
    {
        // picks a random number between 0 and the total length of the array then returns it.
        return (int)Random.Range(0, rockPrefab.Length);
    }
}
