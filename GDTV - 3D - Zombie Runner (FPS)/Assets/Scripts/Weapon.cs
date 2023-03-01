using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 20;
    [SerializeField] private ParticleSystem muzzleFlashFX;
    [SerializeField] private GameObject hitEffectVFX;
     

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        PlayAnimation();
        PlayMuzzleFlash();
        ProcessRayCast();
    }

    private void PlayAnimation() {
        GetComponent<Animator>().SetTrigger("shoot");
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