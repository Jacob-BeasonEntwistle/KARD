using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public enum GameMode
    {
        Singleplayer,
        Multiplayer
    }

    public static GameMode SelectedMode;
}
