using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shipSpawner : MonoBehaviour
{
    public GameObject[] shipPrefab;      // Holds the list of ships to be instantiated later.

    // Time since the previous ship spawn.
    float previousSpawn = -500f;
    // Time of the next spawn.
    float nextSpawn = 3;

    // Update is called once per frame
    void Update()
    {
        // If the time subtract previous spawn is less than the time of the next spawn...
        if (Time.time - previousSpawn > nextSpawn)
        {
            // a ship is selected using the getShip() function...
            int selected = getShip();

            // the time till next spawn is a random number between 4 and 10...
            nextSpawn = Random.Range(4, 10);
            // the time of the previous spawn becomes the new time...
            previousSpawn = Time.time;

            // and an item is spawned from the ship prefab list.
            Instantiate(shipPrefab[selected]);
        }
    }

    // A get function that...
    int getShip()
    {
        // picks a random number between 0 and the total length of the array then returns it.
        return (int)Random.Range(0,shipPrefab.Length);
    }
}
