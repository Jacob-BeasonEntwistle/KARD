using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ships : MonoBehaviour
{
    // [----Camera & Player----]
    // A variable for the camera to be stored at.
    public Camera GameCamera;
    // A variable for the player object.
    private GameObject player;

    // [----Lazer & Shooting----]
    // A variable for the lazer object.
    public GameObject Lazer;
    // A variable to store the transform of the lazer.
    public Transform LazerPos;
    // A float variable to store the time until the next shot.
    private float timer;

    // A public bool that can be used within other scripts
    public static bool hasFired;

    // Start is called before the first frame update.
    void Start()
    {
        // Finds the camera in the scene.
        GameCamera = GameObject.FindObjectOfType<Camera>();
        // Finds the game object labelled Player.
        player = GameObject.FindWithTag("Player");

        // Creates a random transform position on the screen calling two methods.
        transform.position = new Vector2(player.transform.position.x + getRandomDist(), getRandomHeight());
    }

    // Update is called once per frame.
    void Update()
    {
        // The distance between the player and the ship is calculated.
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // If the distance between the player and the ship is less than 10...
        if (distance < 10)
        {
            // the timer is set to the number of time passed...
            timer += Time.deltaTime;

            // and if the timer is greater that 4...
            if (timer > 2.5f)
            {
                // the timer is reset...
                timer = 0;
                // and the blast function is called.
                blast();
            }
        }
    }

    // The blast function.
    void blast()
    {
        // The lazer prefab is instantiated at the laser spawn position.
        Instantiate(Lazer, LazerPos.position, Quaternion.identity);
        // The bool hasFired becomes true.
        hasFired = true;
    }

    // When the collider is triggered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the ship spawns in a moon...
        if (other.gameObject.tag == "Moon")
        {
            Debug.Log("Ship cleared from the moon.");
            // it is destroyed.
            Destroy(gameObject);
        }
    }

    // When the object leaves the bounds of all cameras...
    void OnBecameInvisible()
    {
        // the ship is destroyed.
        Destroy(gameObject);
    }

    // A get function that...
    int getRandomDist()
    {
        // if the player has left the main start area...
        if (player.transform.position.x > 12)
        {
            // the random range to pick from is between 0 and 10...
            return (int)Random.Range(0, 10);
        }

        // but if the player is still in the start area...
        else
        {
            // a random number between 11 and 20 is chosen and then returned.
            // The randomised choice is converted to an integer via (int).
            return (int)Random.Range(11, 20);
        }

    }
    int getRandomHeight()
    {
        // Return will send the value to the getRandomHeight() called earlier in the script.
        // Random.Range will pick a value between the two values within the brackets.
        return Random.Range((-(GameCamera.pixelHeight) / 100) * 2, ((GameCamera.pixelHeight) / 100) * 2);
    }
}
