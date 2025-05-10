using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    // [----Camera & Player----]
    // A variable for the camera to be stored at.
    public Camera GameCamera;
    // A variable for the player object.
    private GameObject player;

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

    // When the collider is triggered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the rock spawns in a moon...
        if (other.gameObject.tag == "Moon")
        {
            Debug.Log("Rock cleared from the moon.");
            // it is destroyed.
            Destroy(gameObject);
        }
    }

    // When the object leaves the bounds of all cameras...
    void OnBecameInvisible()
    {
        // the rock is destroyed.
        Destroy(gameObject);
    }

    // A get function that...
    int getRandomDist()
    {
        // picks a random number between 10 and 15...
        return (int)Random.Range(12, 18);
    }

    int getRandomHeight()
    {
        // Return will send the value to the getRandomHeight() called earlier in the script.
        // Random.Range will pick a value between the two values within the brackets.
        return Random.Range((-(GameCamera.pixelHeight) / 100) * 2, ((GameCamera.pixelHeight) / 100) * 2);
    }
}
