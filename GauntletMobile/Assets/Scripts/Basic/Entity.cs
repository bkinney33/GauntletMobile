using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public enum UpdateType
    {
        HEALING, DAMAGE
    }

    [SerializeField]
    protected double maxHealth;
    protected double currentHealth;
    [SerializeField]
    int damage;
    [Tooltip("If entity does not use projectiles make sure to modify the cleave angle.")]
    [SerializeField]
    float attackRange;
    [Tooltip("Cleave angle will alter the size of the players attack area large cleave angles will create large areas of effect for damage.")]
    [SerializeField]
    float cleaveAngle;
    [SerializeField]
    Projectile projectile;

    public abstract bool AutoAttack();


    public virtual void UpdateHealth(int change, UpdateType typeOfChange)
    {
        if (typeOfChange == UpdateType.HEALING)
        {
            currentHealth += change;
        }
        if (typeOfChange == UpdateType.DAMAGE)
        {
            currentHealth -= change;
        }
        if (currentHealth <= 0) { Die(); }
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }

    public virtual void Die()
    {
        throw new NotImplementedException();
    }
}
