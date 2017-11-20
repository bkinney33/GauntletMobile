using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warlock : Class {

    [Header("Auto Attack Settings")]
    [SerializeField]
    protected float autoAttackRange = 5.0f;
    [SerializeField]
    float autoAttackDuration = 3.0f;
    [SerializeField]
    float autoAttackProjectileSpeed = 3.0f;
    [SerializeField]
    Projectile warlockAutoAttack;
    float lastTick;

    public override bool AutoAttack()
    {

        if ((lastTick + autoAttackSpeed) <= Time.time)
        {
            lastTick = Time.time;
            Vector3 direction = transform.up;
            Projectile p = Instantiate(warlockAutoAttack, transform);
            p.Setup(direction, autoAttackProjectileSpeed, autoAttackRange, this);
            return true;
        }
        return false;
    }

    public override bool SpecialSkill()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        base.Start();
        lastTick = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    public override void HitEnemy()
    {
        
    }
}
