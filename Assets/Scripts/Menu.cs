using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // A method that is assigned to a button which loads singlplayer mode.
    public void playSingleplayer()
    {
        GameSettings.SelectedMode = GameSettings.GameMode.Singleplayer;
        SceneManager.LoadScene("Briefing");
    }
    // A method that is assigned to a button which loads multiplayer mode.
    public void playMultiplayer()
    {
        GameSettings.SelectedMode = GameSettings.GameMode.Multiplayer;
        SceneManager.LoadScene("Briefing");
    }
    // A method that is assigned to a button which closes the game.
    public void quitGame()
    {
        Application.Quit();
    }
}
