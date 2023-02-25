using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() {
        currentBalance = startingBalance;
        UpdateUI();
    }

    public int GetBalance() {
        return currentBalance;
    }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        UpdateUI();
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0) {
            ReloadLevel();
        }

        UpdateUI();
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateUI() {
        scoreText.text = "Gold: " + currentBalance.ToString();
    }
}
