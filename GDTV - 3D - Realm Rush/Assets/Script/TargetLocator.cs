using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class TargetLocator : MonoBehaviour
{
    [Header("Weapon and Projectile")]
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float weaponFireRate;
    [SerializeField] private float shotRange = 15f;
    [SerializeField] private Projectile projectile;
    
    private GameObject parent;
    private Transform target;
    private float fireRateTimer;
    private bool hasTarget = false;
    private bool isOutOfRange = false;

    private void Awake() {
        parent = GameObject.Find("SpawnAtRuntime");
        fireRateTimer = weaponFireRate;
    }
    
    private void Update() {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget() {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies) {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance) {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon() {
        if (target != null) {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            if (targetDistance <= shotRange) {
                weapon.LookAt(target);
                CheckFireRate();
            }
        }
    }

    private void CheckFireRate() {
        // if the arrow is available
        if (fireRateTimer < weaponFireRate) {
            fireRateTimer += Time.deltaTime;            
        } else {
            if (FindObjectOfType<EnemyMover>() != null) {
                Shoot();
                fireRateTimer = 0f;            
            }
        }                  
    }

    private void Shoot() {
        Instantiate(projectile.gameObject, projectileSpawnPoint.position, projectileSpawnPoint.rotation, parent.transform);              
    }
}