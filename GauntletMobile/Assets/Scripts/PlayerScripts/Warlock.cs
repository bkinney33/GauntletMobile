using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Warlock : Class {

    [Header("Mana Settings")]
    [SerializeField]
    float manaRegenInterval = 1.0f;
    [SerializeField]
    short manaRegenValue = 1;

    [Header("Auto Attack Settings")]
    [SerializeField]
    ObjectPool projectilePool;
    [SerializeField]
    string projectileName;
    [SerializeField]
    protected float autoAttackRange = 5.0f;
    [SerializeField]
    float autoAttackProjectileSpeed = 3.0f;
    [Header("Warlock Hellfire Settings")]
    [SerializeField]
    string hellfireName;
    [SerializeField]
    short warlockSpecialCost = 5;
    [SerializeField]
    protected float specialAttackRange = 5.0f;
    [SerializeField]
    float specialAttackProjectileSpeed = 1.0f;
    float manaRengen;
    float lastTick;

    public override bool AutoAttack()
    {
        if ((lastTick + autoAttackSpeed) <= Time.time)
        {
            lastTick = Time.time;
            GameObject g = projectilePool.GetPooledObject(projectileName);
            if (g == null) { return false; }
            Projectile p = g.GetComponent<Projectile>();
            if (p == null) { return false; }
            g.SetActive(true);
            p.transform.position = transform.root.position;
            Vector3 direction = transform.root.up;
            float y = transform.root.eulerAngles.y;
            direction = Quaternion.Euler(0, 0, -y) * direction;
            p.Setup(direction, autoAttackProjectileSpeed, autoAttackRange, transform.root.gameObject.GetComponent<Entity>());
            return true;
        }
        return false;
    }

    public override bool SpecialSkill()
    {
        if ((lastTick + autoAttackSpeed) <= Time.time && SpendResource(warlockSpecialCost))
        {
            lastTick = Time.time;
            GameObject g = projectilePool.GetPooledObject(hellfireName);
            if (g == null) { return false; }
            Projectile p = g.GetComponent<Projectile>();
            if (p == null) { return false; }
            g.SetActive(true);
            p.transform.position = transform.root.position;
            Vector3 direction = transform.root.up;
            float y = transform.root.eulerAngles.y;
            direction = Quaternion.Euler(0, 0, -y) * direction;
            p.Setup(direction, specialAttackProjectileSpeed, specialAttackRange, transform.root.gameObject.GetComponent<Entity>());
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        base.Start();
        lastTick = Time.time;
        manaRengen = Time.time;
        projectilePool = GameObject.Find("ProjectilePool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if(manaRengen + manaRegenInterval < Time.time)
        {
            manaRengen = Time.time;
            GainResource(manaRegenValue);
        }
	}

    public override void HitEnemy(bool notDead, Entity enemy)
    {
        if (!notDead)
        {
            EnemyKilled();
        }
    }

    private void EnemyKilled()
    {
        Debug.Log("Enemy Killed");
    }
}
