using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance = 0;

    private void Awake() {
        currentBalance = startingBalance;
    }

    public int GetBalance() {
        return currentBalance;
    }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0) {
            ReloadLevel();
        }
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
