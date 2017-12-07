using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Hunter : Class {

    [Header("Focus Settings")]
    [SerializeField]
    short focusGainOnKill;
    [SerializeField]
    ObjectPool projectilePool;

    [Header("Auto Attack Settings")]
    [SerializeField]
    string projectileName;
    [SerializeField]
    protected float autoAttackRange = 5.0f;
    [SerializeField]
    float autoAttackProjectileSpeed = 3.0f;

    [Header("Hunter Snipe Settings")]
    [SerializeField]
    string snipeShotProjectileName;
    [SerializeField]
    short hunterSpecialCost = 5;
    [SerializeField]
    protected float specialAttackRange = 5.0f;
    [SerializeField]
    float specialAttackProjectileSpeed = 1.0f;
    [SerializeField]
    short hpPerHit = 1;
    private Transform body;

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
            Vector3 direction = -body.up;
            float y = transform.root.eulerAngles.y;
            direction = Quaternion.Euler(0, 0, -y) * direction;
            p.Setup(direction, autoAttackProjectileSpeed, autoAttackRange, transform.root.gameObject.GetComponent<Entity>());
            return true;
        }
        return false;
    }

    public override void HitEnemy(bool notDead, Entity enemy)
    {
        if (!notDead)
        {
            EnemyKilled();
        }
    }
    internal void HitEnemy(bool notDead, Entity e, bool special)
    {
        UpdateHealth(hpPerHit, UpdateType.HEALING, true);
        HitEnemy(notDead, e);
    }
    public void EnemyKilled()
    {
        GainResource(focusGainOnKill);
    }

    public override bool SpecialSkill()
    {
        if ((lastTick + autoAttackSpeed) <= Time.time && SpendResource(hunterSpecialCost))
        {
            lastTick = Time.time;
            GameObject g = projectilePool.GetPooledObject(snipeShotProjectileName);
            if (g == null) { return false; }
            Projectile p = g.GetComponent<Projectile>();
            if (p == null) { return false; }
            g.SetActive(true);
            p.transform.position = transform.root.position;
            Vector3 direction = -body.up;
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
        body = transform.Find("Body");
        projectilePool = GameObject.Find("ProjectilePool").GetComponent<ObjectPool>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}
}
