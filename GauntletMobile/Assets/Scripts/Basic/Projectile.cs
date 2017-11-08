using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed;
    float projectileRange;
    int projectileDamage;

    public Projectile(float range, int damage)
    {
        projectileRange = range;
        projectileDamage = damage;
    }
}