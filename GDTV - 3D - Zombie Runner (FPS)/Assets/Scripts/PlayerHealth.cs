using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField] private int maxHealth = 200;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image bloodImage;

    private Color transparentWhite = new Color(255f, 255f, 255f, 0);
    private float timer = 0f;

    private void Start() {
        currentHealth = startHealth;
    }

    private void Update() {
        if (bloodImage.color.a > 0) {
            timer += Time.deltaTime;
            bloodImage.color = Color.Lerp(bloodImage.color, transparentWhite, timer);
        } else {
            timer = 0f;
        }
    }

    public void Damage(int damage) {
        BloodUI();
        currentHealth -= damage;        
        if(currentHealth < 0) {
            Debug.Log("Player Died");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    private void BloodUI() {
        Vector3 randomZ = new Vector3(0f, 0f, UnityEngine.Random.Range(0f, 360f));
        bloodImage.rectTransform.rotation = Quaternion.Euler(randomZ);
        bloodImage.color = Color.white;
    }
}