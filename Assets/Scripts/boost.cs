using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject player;

    private void Start()
    {
        // Finds the camera in the scene.
        playerCamera = GameObject.FindObjectOfType<Camera>();
        
        // Finds the game object labelled Player.
        player = GameObject.FindWithTag("Player");

        // Creates a random transform position on the screen calling two methods.
        transform.position = new Vector2(player.transform.position.x + getRandomX(), getRandomHeight());
    }

    // When the trigger zone is entered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the colliding game object is tagged "Player"...
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement movement = other.gameObject.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                // a message is sent to the console...
                Debug.Log("BOOST");
                movement.isBoosting = true;
                // and the boost object is destroyed.
                Destroy(gameObject);
            }
        }

        // If the cargo spawns in a moon...
        if (other.gameObject.tag == "Moon")
        {
            Debug.Log("Boost cleared from the moon.");
            // it is destroyed.
            Destroy(gameObject);
        }
    }

    // A get function that...
    int getRandomX()
    {
        // picks a random number between -11 and 11, then returns it.
        // The randomised choice is converted to an integer via (int).
        return (int)Random.Range(-11, 11);
    }

    float getRandomHeight()
    {
        // Return will send the value to the getRandomHeight() called earlier in the script.
        // Random.Range will pick a value between the two values within the brackets.
        return Random.Range((-(playerCamera.pixelHeight) / 100) * 1.2f, ((playerCamera.pixelHeight) / 100) * 1.2f);
    }
}
