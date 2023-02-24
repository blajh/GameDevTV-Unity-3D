using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [Header("Weapon and Projectile")]
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float weaponFireRate;
    [SerializeField] private Projectile projectile;

    private Transform target;
    private float fireRateTimer;

    private void Start() {
        target = FindObjectOfType<EnemyMover>().transform;
        fireRateTimer = weaponFireRate;
    }

    private void Update() {
        AimWeapon();
        CheckFireRate();
    }

    private void AimWeapon() {
        weapon.LookAt(target);
    }

    private void CheckFireRate() {
        // if the arrow is available
        if (fireRateTimer < weaponFireRate) {
            fireRateTimer += Time.deltaTime;            
        } else {
            Shoot();
            fireRateTimer = 0f;            
        }                  
    }

    private void Shoot() {
        Instantiate(projectile.gameObject, projectileSpawnPoint.position, projectileSpawnPoint.rotation);    
    }
}
