using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // If the escape key is pressed...
        if (Input.GetKey(KeyCode.Escape))
        {
            // the main menu is loaded
            SceneManager.LoadScene("MainMenu");
        }
    }
}
