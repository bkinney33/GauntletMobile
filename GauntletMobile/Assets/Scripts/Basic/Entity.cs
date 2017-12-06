using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public enum UpdateType
    {
        HEALING, DAMAGE
    }

    [Header("Health Settings", order = 3)]
    [SerializeField]
    protected double maxHealth;
    protected double currentHealth;
    [Header("Damage Settings", order = 4)]
    [SerializeField]
    protected int damage;
    [Tooltip("How Long the Collider for an Auto Attack sticks around.")]
    [SerializeField]
    protected float autoAttackSpeed;
    public float wallDamageTick;

    public abstract bool AutoAttack();

    public virtual int GetDamage()
    {
        return damage;
    }

    public virtual void HitEnemy(bool deadEnemy, Entity enemy)
    {
    }

    internal void HitEnemy(bool notDead, Entity e, bool v)
    {
        throw new NotImplementedException();
    }

    public virtual bool UpdateHealth(int change, UpdateType typeOfChange)
    {
        if (typeOfChange == UpdateType.HEALING)
        {
            currentHealth += change;
        }
        if (typeOfChange == UpdateType.DAMAGE)
        {
            currentHealth -= change;
        }
        if (currentHealth <= 0)
        {
            
            Die();
            return false;
        }
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        return true;
    }

    public virtual void Die()
    {
        Debug.Log("Dead Creature.");
        gameObject.transform.root.gameObject.SetActive(false);//gameObject.transform.parent.gameObject.SetActive(false);
    }
}
