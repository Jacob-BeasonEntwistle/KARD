using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // A method that is assigned to a button which loads singlplayer mode.
    public void playSingleplayer()
    {
        SceneManager.LoadScene("Singleplayer");
    }
    // A method that is assigned to a button which loads multiplayer mode.
    public void playMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }
    // A method that is assigned to a button which closes the game.
    public void quitGame()
    {
        Application.Quit();
    }
}
