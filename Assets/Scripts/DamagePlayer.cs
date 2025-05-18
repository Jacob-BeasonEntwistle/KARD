using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject takenDamageUI;
    public bool destroyOnHit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (takenDamageUI != null)
        {
            takenDamageUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1);

                if (takenDamageUI != null)
                {
                    takenDamageUI.SetActive(true);
                }

                if (destroyOnHit)
                {
                    Destroy(gameObject);
                }

                Debug.Log($"{gameObject.name} hit the player!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && takenDamageUI != null)
        {
            takenDamageUI.SetActive(false);
        }
    }
}
