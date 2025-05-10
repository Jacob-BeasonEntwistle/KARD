using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrClean : enemy
{
    // All other functionality is inherited from the enemy class.

    // protected - allows for the variable to be accessed from the subclasses
    // override - overrides a virtual variable
    // virtual - allows a subclass to override it
    // Sets the target tag to cargo.
    protected override string TargetTag => "Cargo";

    // 'new' creates a new version of the update so that it is different to the enemy version.
    new void Update()
    {
        // base.Update() calls the update inherited from the enemy so that it still occurs.
        base.Update();
        // The lighSkip() method is called.
        lightSkip();
    }

    // This method is called when MrClean is too far away from cargo.
    void lightSkip()
    {
        // If mrClean has targeted cargo...
        if (target != null)
        {
            // and if the distance is greater than 20...
            if (Vector3.Distance(this.transform.position, target.position) > 20f)
            {
                // then mrClean does a lightSkip and speeds towards the cargo.
                speed = 50f;
            }

            // but once mrClean gets within 20 units of the cargo...
            else
            {
                // his speed returns to normal.
                speed = 2f;
            }
        }
    }

    // When the zone is triggered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the object that triggered it is Cargo...
        if (other.gameObject.tag == "Cargo")
        {
            // the cargo is destroyed meaning the player cannot collect it.
            Destroy(other.gameObject);
        }
    }
}
