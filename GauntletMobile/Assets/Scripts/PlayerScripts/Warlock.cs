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
    protected float autoAttackRange = 5.0f;
    [SerializeField]
    float autoAttackProjectileSpeed = 3.0f;
    [SerializeField]
    Projectile warlockAutoAttack;
    [Header("Warlock Hellfire Settings")]
    [SerializeField]
    protected Projectile warlockSpecial;
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
            Projectile p = Instantiate(warlockAutoAttack, transform.position + new Vector3(0, 1, 0), transform.rotation);
            float heading = Mathf.Atan2(CrossPlatformInputManager.GetAxis("Horizontal"), -CrossPlatformInputManager.GetAxis("Vertical"));
            Vector3 direction = Quaternion.Euler(0f, 0f, (((heading) * Mathf.Rad2Deg))).eulerAngles;

            p.Setup(direction, autoAttackProjectileSpeed, autoAttackRange, this);
            return true;
        }
        return false;
    }

    public override bool SpecialSkill()
    {
        if ((lastTick + autoAttackSpeed) <= Time.time && SpendResource(warlockSpecialCost))
        {
            lastTick = Time.time;
            Projectile p = Instantiate(warlockSpecial, transform.position + new Vector3(0, 1, 0), transform.rotation);
            float heading = Mathf.Atan2(CrossPlatformInputManager.GetAxis("Horizontal"), -CrossPlatformInputManager.GetAxis("Vertical"));
            Vector3 direction = Vector3.up; //Quaternion.Euler(0f, 0f, (((heading) * Mathf.Rad2Deg))).eulerAngles;

            p.Setup(direction, specialAttackProjectileSpeed, specialAttackRange, this);
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        base.Start();
        lastTick = Time.time;
        manaRengen = Time.time;
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

    public override void HitEnemy(bool notDead)
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
