using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = ("CARGO VALUE: " + score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = ("CARGO VALUE: " + score);
    }
}
