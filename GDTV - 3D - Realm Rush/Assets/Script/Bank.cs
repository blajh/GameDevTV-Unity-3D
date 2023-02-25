using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
        return true;
    }

    public bool Withdraw(int amount) {
        if (currentBalance >= Mathf.Abs(amount)) {
            currentBalance -= amount;
            return true;
        } else {
            return false;
        }
    }
}
