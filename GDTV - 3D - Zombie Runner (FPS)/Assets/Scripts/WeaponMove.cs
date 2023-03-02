using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Vector3 zoomedInTransformPosition;
    [SerializeField] private Vector3 zoomedOutTransformPosition;
    [SerializeField] private float moveSpeed = 5f;
    
    public void MoveWeaponsIn() {
        foreach (Weapon weapon in weapons) {
            weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, zoomedInTransformPosition, Time.deltaTime * moveSpeed);
        }
    }

    public void MoveWeaponsOut() {
        foreach (Weapon weapon in weapons) {
            weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, zoomedOutTransformPosition, Time.deltaTime * moveSpeed);
        }
    }
}