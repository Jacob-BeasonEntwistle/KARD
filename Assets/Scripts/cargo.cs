using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargo : MonoBehaviour
{
    // A variable for the camera to be stored at.
    public Camera playerCamera;
    // A variable for a reference to the player object to be stored.
    public GameObject player;

    // The value of the cargo.
    private int value;
    /* A bool that states whether the cargo is collected or not 
     * - to be used in audio manager. */
    public static bool cargoCollected;

    // A reference to the CargoType script containing the enum.
    public CargoType cargoType;

    // Start is called before the first frame update.
    void Start()
    {
        // Finds the camera in the scene.
        playerCamera = GameObject.FindObjectOfType<Camera>();

        // Finds the game object labelled Player.
        player = GameObject.FindWithTag("Player");

        // Creates a random transform position on the screen calling two methods.
        transform.position = new Vector2(player.transform.position.x + getRandomX(), getRandomHeight());

        // The value of the expression (cargoType) is compared to the values of each case...
        switch (cargoType)
        {
            // If the value is the same as Basic (or 0)...
            case CargoType.Basic:
                // the value is 25.
                value = 25;
                break;
            // If the value is the same as Rare (or 1)...
            case CargoType.Rare:
                // the value is 50.
                value = 50;
                break;
        };

        // A message is sent to the Debug Log displaying the value and selected cargo type.
        Debug.Log($"Cargo ({cargoType}) is worth +" + value + " points");
        // Cargo collected is false by default.
        cargoCollected = false;
    }

    // When the collider is triggered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // and if the player triggers it...
        if (other.gameObject.tag == "Player")
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(value);
                Debug.Log("Cargo collected, +" + value + " points");
                cargoCollected = true;
                Destroy(gameObject);
            }
        }

        // If the cargo spawns in a moon...
        if (other.gameObject.tag == "Moon")
        {
            Debug.Log("Cargo cleared from the moon.");
            // it is destroyed.
            Destroy(gameObject);
        }
    }

    // A get function that...
    float getRandomX()
    {
        // picks a random number between -11 and 11, then returns it.
        // The randomised choice is converted to an integer via (int).
        return (int)Random.Range(-11, 11);
    }
    float getRandomHeight()
    {
        // Return will send the value to the getRandomHeight() called earlier in the script.
        // Random.Range will pick a value between the two values within the brackets.
        return Random.Range((-(playerCamera.pixelHeight) / 100) * 1.5f, ((playerCamera.pixelHeight) / 100) * 1.5f);
    }
}
