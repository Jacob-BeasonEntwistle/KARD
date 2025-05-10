using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // A variable that stores the speed at which the enemy moves.
    public float speed = 2f;
    // A variable to store the Rigidbody2D component.
    public Rigidbody2D rb;
    // A variable to store the target for the enemy to follow.
    // protected - allows for the variable to be accessed from subclasses but not completely public.
    protected Transform target;
    // A bool to determine whether the enemy is alive or not.
    private bool isAlive = true;

    // protected - allows for the variable to be accessed from the subclasses
    // virtual - allows a subclass to override it
    // Sets the target tag to default.
    protected virtual string TargetTag => "default";

    // Start is called before the first frame update
    void Start()
    {
        // This gets the rigidbody2D component and stores it in the rb variable.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    // protected - allows for the variable to be accessed from subclasses but not completely public.
    protected void Update()
    {
        // If the enemy is alive...
        if (isAlive)
        {
            // and if there is no target...
            if (target == null)
            {
                // the enemy stops moving...
                rb.velocity = Vector2.zero;
                // and the cargoScan() is run.
                targetScan();
            }

            // But if there is a target...
            else
            {
                //the the method is called to then move the enemy to the target.
                moveTowardsTarget();
            }
        }
    }

    // This method makes the enemy choose its next target.
    // virtual - allows a subclass to override it
    public virtual void targetScan()
    {
        // The enemy searches for an object in the scene with the target tag label...
        GameObject targetObject = GameObject.FindWithTag(TargetTag);

        // if one is found...
        if (targetObject != null)
        {
            // the target becomes the transform of the targeted object in the scene...
            target = targetObject.transform;
            // and the enemy rotates to look at it.
            transform.up = target.position - transform.position;
        }
    }
    
    // virtual - allows a subclass to override it
    // This method controls the movement of the enemy.
    public virtual void moveTowardsTarget()
    {
        // The direction is the position of the target in the scene minus the current position of the enemy.
        Vector2 direction = (target.position - transform.position).normalized;
        // The velocity of the enemy is the direction multiplied by the speed.
        rb.velocity = direction * speed;
        Debug.Log("Moving towards target");
    }
}
