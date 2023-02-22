using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int score = 0;

    public void AddToScore(int amount) {
        score += amount;
    }

    public int GetScore() {
        return score;
    }
}