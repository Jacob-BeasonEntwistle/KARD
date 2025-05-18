using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoSpawner : MonoBehaviour
{
    public GameObject[] cargoPrefab;    // Holds the cargo prefabs to be instantiated later.

    // Time since the previous cargo spawn.
    float previousSpawn = -300f;
    // Time of the next spawn.
    float nextSpawn = 3;

    // Update is called once per frame
    void Update()
    {
        // If the time subtract previous spawn is less than the time of the next spawn...
        if (Time.time - previousSpawn > nextSpawn)
        {
            // a ship is selected using the getCargo() function...
            int selected = getCargo();

            // the time till next spawn is a random number between 4 and 10...
            nextSpawn = Random.Range(4, 10);
            // the time of the previous spawn becomes the new time...
            previousSpawn = Time.time;
            // and an item is spawned from the cargo prefab.
            GameObject spawnedCargo = Instantiate(cargoPrefab[selected]);
            // The cargo script is retrieved from the instantiated cargo.
            cargo cargoScript = spawnedCargo.GetComponent<cargo>();
            // Then the type of the cargo is assigned based on the randomly selected index from the getCargo().
            cargoScript.cargoType = (CargoType)selected;
        }
    }

    // A get function that...
    int getCargo()
    {
        // picks a random number between 0 and the total size of the list then returns it.
        return (int)Random.Range(0, cargoPrefab.Length);
    }
}
