using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impaler : enemy
{
    // protected - allows for the variable to be accessed from the subclasses
    // override - overrides a virtual variable
    // virtual - allows a subclass to override it
    // Sets the target tag to default.
    protected override string TargetTag => "Player";
    // A new speed variable for the impaler script to use.
    float impSpeed = 6f;

    // A Vector2 that stores the locked coordinates of the target.
    private Vector2 lockedPos;
    // A bool to determine when the impaler has a lock on.
    private bool targetLocked = false;

    // A float to store time to wait before trying to attack again.
    private float wait = 2f;
    // A float to track the time passed.
    private float timer = 0f;

    // 'new' creates a new version of the update so that it is different to the enemy version.
    new void Update()
    {
        // If the impaler has a lock on the target...
        if (targetLocked)
        {
            // it fires itself towards it.
            moveTowardsTarget();
        }

        // Otherwise...
        else
        {
            // if the timer is less than or equal to 0...
            if (timer <= 0f)
            {
                // the impaler scans the players location again.
                targetScan();
            }
            // but if the timer is above 0...
            else
            {
                // the the amount of time passed in the scene is subtracted from the curremt time on the timer.
                timer -= Time.deltaTime;
            }
        }
    }

    // This method makes the enemy choose its next target.
    // virtual - allows a subclass to override it
    public override void targetScan()
    {
        // The enemy searches for an object in the scene with the target tag label...
        GameObject targetObject = GameObject.FindWithTag(TargetTag);

        // if one is found...
        if (targetObject != null)
        {
            // the coordinates are locked...
            lockedPos = targetObject.transform.position;
            // locked becomes true...
            targetLocked = true;
            // and the enemy rotates to look at it...
            transform.up = (Vector3)lockedPos - transform.position;
            // then the impaler waits before attacking again.
            timer = wait;
        }
    }

    // virtual - allows a subclass to override it
    // This method controls the movement of the enemy.
    public override void moveTowardsTarget()
    {
        // If the impaler has a lock on the target...
        if (targetLocked)
        {
            // the direction of the target is calculated by taking the current position away from the target lock coords...
            Vector2 direction = (lockedPos - (Vector2)transform.position).normalized;
            // and the velocity of the impaler is the direction multiplied by the impalers speed.
            rb.velocity = direction * impSpeed;

            // but if the distance from the locked target position is less than 0.1...
            if (Vector2.Distance(transform.position, lockedPos) < 0.1f)
            {
                // the impaler stops moving...
                rb.velocity = Vector2.zero;
                // it loses its lock on the player...
                targetLocked = false;
                // and waits before finding a new lock on.
                timer = wait;
            }
        }
    }
}
