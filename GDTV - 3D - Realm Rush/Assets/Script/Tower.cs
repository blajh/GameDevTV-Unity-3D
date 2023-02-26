using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;
    Bank bank;

    public bool CreateTower(Tower tower, Vector3 position, GameObject parent) {

        bank = FindObjectOfType<Bank>();

        if (bank == null) {
            return false; 
        }

        if (bank.GetBalance() >= cost) {
            Instantiate(tower.gameObject, position, Quaternion.identity, parent.transform);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }

    public bool CanBuild() {

        bank = FindObjectOfType<Bank>();

        if (bank == null) {
            return false;
        }

        if (bank.GetBalance() >= cost) {
            return true;
        }

        return false;
    }
}
