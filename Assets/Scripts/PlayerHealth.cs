using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    public Animator[] ledAnimators;

    // Start is called before the first frame update
    void Start()
    {
        currentHearts = maxHearts;
        UpdateLEDs();
    }

    public void TakeDamage(int amount)
    {
        currentHearts -= amount;
        currentHearts = Mathf.Max(currentHearts, 0);
        UpdateLEDs();

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    void UpdateLEDs()
    {
        for (int i = 0; i < ledAnimators.Length; i++)
        {
            bool isOn = i < currentHearts;
            ledAnimators[i].SetBool("IsOn", isOn);
        }
    }

    void Die()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        GameManager manager = managerObj.GetComponent<GameManager>();
        if (manager != null)
        {
            Debug.Log("Player died!");
            manager.MainMenu();
        }
    }
}
