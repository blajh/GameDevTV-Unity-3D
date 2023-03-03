using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int ammoAmount;    

    private Ammo ammo;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ammo>() != null) {
            ammo = other.gameObject.GetComponent<Ammo>();

            switch (ammoType) {
                case AmmoType.Bullets:
                    ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
                    Destroy(gameObject);
                    return;
                case AmmoType.Rockets:
                    ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
                    Destroy(gameObject);
                    return;
                case AmmoType.Shells:
                    ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
                    Destroy(gameObject);
                    return;
            }
        }
    }
}
