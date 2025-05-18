using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Briefing : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;

    private int page;

    // Start is called before the first frame update
    void Start()
    {
        page = 1;
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && page == 1)
        {
            page += 1;
            Page1.SetActive(false);
            Page2.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && page == 2)
        {
            page += 1;
            Page2.SetActive(false);
            Page3.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && page == 3)
        {
            Page3.SetActive(false);

            if (GameSettings.SelectedMode == GameSettings.GameMode.Singleplayer)
            {
                SceneManager.LoadScene("Singleplayer");
            }
            else
            {
                SceneManager.LoadScene("Multiplayer");
            }
        }
    }
}
