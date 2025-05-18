using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Stores the UI game object that shows if the player has been damaged.
    public GameObject takenDamage;

    // Start is called before the first frame update.
    void Start()
    {
        // The game object is set to inactive by default.
        takenDamage.SetActive(false);
    }

    // When the zone is triggered...
    void OnTriggerEnter2D(Collider2D other)
    {
        // if the colliding object has the tag "Player"...
        if (other.gameObject.tag == "Player")
        {
            PlayerScore pScore = other.gameObject.GetComponent<PlayerScore>();
            if (pScore != null)
            {
                // the score decreases by 25...
                pScore.score -= 25;
                // a message is sent to the console...
                Debug.Log("Player has crashed into moon");
                // and the UI 'Damaged' panel becomes active.
                takenDamage.SetActive(true);
            }
        }
    }

    // When the zone is exited...
    void OnTriggerExit2D(Collider2D other)
    {
        // if the exiting object is tagged "Player"...
        if (other.gameObject.tag == "Player")
        {
            // the UI element is hidden again.
            takenDamage.SetActive(false);
        }
    }
}
