using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Start() {
        DisplayScore();
    }

    public void AddToScore(int amount) {
        score += amount;
        DisplayScore();
    }

    private void DisplayScore() {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public int GetScore() {
        return score;
    }
}