using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;

    private void Awake() {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath() {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
