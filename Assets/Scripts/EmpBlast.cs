using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EMP
{
    // A variable that stores the radius of the EMP.
    public float radius;
    // A variable that stores the cooldown time of the EMP.
    public float cooldown;
    // A variable that stores the time that the enemies are deactivated for.
    public float timeDeactivated;
    // A variable that checks whether the EM pulse is active.
    public bool pulseActive;

    // A constructor for the EMP struct
    // This holds all the preset variables to be used in the EMP class.
    public EMP(float Radius, float Cooldown, float TimeDeactivated, bool PulseActive)
    {
        radius = Radius;
        cooldown = Cooldown;
        timeDeactivated = TimeDeactivated;
        pulseActive = PulseActive;
    }
}

public class EmpBlast : MonoBehaviour
{
    // This brings the struct into the EmpBlast class.
    private EMP empBlast;

    // Start is called before the first frame update.
    void Start()
    {
        // Creates a new instance of EMP and stores it as empBlast.
        empBlast = new EMP(20f, 5f, 3f, false);
        // Sends a message to the console.
        Debug.Log("EMP: Radius = " + empBlast.radius + ", Cooldown = " + empBlast.cooldown);
    }

    // Update is called once per frame.
    void Update()
    {
        // If the cooldown is greater than 0...
        if (empBlast.cooldown > 0)
        {
            // the cooldown decreases as time passes...
            empBlast.cooldown -= Time.deltaTime;
            // and a message is sent to the console (the cooldown value is turned to an int for better readability).
            Debug.Log("Cooldown: " + (int)empBlast.cooldown);
        }

        // If the pulse is active...
        if (empBlast.pulseActive)
        {
            // the time that enemies spend deactivated decreases as time passes...
            empBlast.timeDeactivated -= Time.deltaTime;
            // and a message is sent to the console.
            Debug.Log("Time Deactivated: " + (int)empBlast.timeDeactivated);

            // If the time is less than or equal to 0...
            if (empBlast.timeDeactivated <= 0)
            {
                // the enableEnemies() method is called...
                enableEnemies();
                // the pulse is deactivated...
                empBlast.pulseActive = false;
                // and a message is sent to the console.
                Debug.Log("EMP Deactivated");
            }
        }

        // The activateEMP() method is called.
        activateEMP();
    }

    // A method that triggers the EMP.
    void activateEMP()
    {
        // If the cooldown is less than or equal to 0...
        if (empBlast.cooldown <= 0)
        {
            // and the EMPulse button (J for keyboard) is pressed...
            if (Input.GetButton("EMPulse"))
            {
                // a message is sent to the console...
                Debug.Log("EMP ACTIVATED");
                // the pulse becomes active...
                empBlast.pulseActive = true;
                // the cooldown is reset...
                empBlast.cooldown = 4f;
                // and the disableEnemies() method is called.
                disableEnemies();
            }
        }
    }

    // This method disables enemies within the radius.
    void disableEnemies()
    {
        // A message is sent to the console to check that the function is called.
        Debug.Log("ENEMIES DISABLED");

        // A Vector2 is created to store the current location of the player (EMP origin point).
        Vector2 empPos = transform.position;
        // The radius is retrieved from the empBlast radius from the EMP struct.
        float empRadius = empBlast.radius;

        // The colliders in the surrounding area (all colliders within the overlap circle) are put into an array.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(empPos, empRadius);
        // A message is sent to the console to say how many colliders were detected.
        Debug.Log("Number of colliders within range: " + colliders.Length);

        // For every collider within the array...
        foreach (Collider2D collider in colliders)
        {
            // if the collider has the tag "Enemy"...
            if (collider.CompareTag("Enemy"))
            {
                // a message is sent to the console with the name of the collider attached...
                Debug.Log("Disabling enemy: " + collider.name);
                // the enemy's script component is retrieved...
                enemy Enemy = collider.GetComponent<enemy>();
                // if the enemy is present...
                if (Enemy != null)
                {
                    // the Rigidbody2D is retrieved from the collider...
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    // and the enemy is frozen by activating all restraints (freezing movement on the x and y axis).
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
    }

    // This method enables enemies within the radius.
    void enableEnemies()
    {
        Debug.Log("ENEMIES ENABLED");

        // A Vector2 is created to store the current location of the player (EMP origin point).
        Vector2 empPos = transform.position;
        // The radius is retrieved from the empBlast radius from the EMP struct.
        float empRadius = empBlast.radius;

        // The colliders in the surrounding area (all colliders within the overlap circle) are put into an array.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(empPos, empRadius);

        // For every collider within the array...
        foreach (Collider2D collider in colliders)
        {
            // if the collider has the tag "Enemy"...
            if (collider.CompareTag("Enemy"))
            {
                // a message is sent to the console with the name of the collider attached...
                Debug.Log("Enabling enemy: " + collider.name);
                // the enemy's script component is retrieved...
                enemy Enemy = collider.GetComponent<enemy>();
                // if the enemy is present...
                if (Enemy != null)
                {
                    // the Rigidbody2D component is retrieved from the collider...
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    // and the constraints are removed from the enemy.
                    rb.constraints = RigidbodyConstraints2D.None;
                }
            }
        }
    }
}