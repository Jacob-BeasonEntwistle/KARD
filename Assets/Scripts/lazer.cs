using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    // A variable to store the player object.
    private GameObject player;
    // A variable to store the rigidbody of the lazer.
    private Rigidbody2D rb;
    // A variable to store the force of the lazer fired.
    private float force = 10f;

    // Start is called before the first frame update.
    void Start()
    {
        // Gets the rigidbody attached to the lazer object.
        rb = GetComponent<Rigidbody2D>();
        // Gets a reference to the object with the tag "Player".
        player = GameObject.FindGameObjectWithTag("Player");

        // Calculates the direction for the lazer to travel in using the players position.
        Vector3 direction = player.transform.position - transform.position;
        // Applies a velocity to the instantiated lazer object.
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // When the object leaves the bounds of all cameras...
    void OnBecameInvisible()
    {
        // the lazer is destroyed.
        Destroy(gameObject);
    }
}
