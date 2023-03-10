using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera FPCamera;
    
    [Header("Stats")]
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float fireRateTime = 1f;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType ammoType;

    [Header("Effecs")]
    [SerializeField] private ParticleSystem muzzleFlashFX;
    [SerializeField] private GameObject hitEffectVFX;

    [Header("Ammo UI")]
    [SerializeField] private TextMeshProUGUI ammoText;

    private float timeSinceShot = 0f;

    private void Update() {
        DisplayAmmo();
        timeSinceShot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && IsFireRateReady()) {
            Shoot();
        }
    }

    private void DisplayAmmo() {
        ammoText.text = "AMMO - " + ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    private bool IsFireRateReady() {
        return timeSinceShot >= fireRateTime;
    }

    private void Shoot() {
        if (ammoSlot.GetCurrentAmmo(ammoType) >= 1) {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayAnimation("shoot");
            PlayMuzzleFlash();
            ProcessRayCast();
        } else {
            PlayAnimation("shootNoAmmo");
        }
        timeSinceShot = 0f;
    }

    private void PlayAnimation(string trigger) {
        GetComponent<Animator>().SetTrigger(trigger);
    }

    private void PlayMuzzleFlash() {
        muzzleFlashFX.Play();
    }

    private void ProcessRayCast() {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            CreateHitImpact(hit);            
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        } else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) {        
        GameObject impact = Instantiate(hitEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f); 
    }
}