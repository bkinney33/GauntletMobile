using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Hunter : Class {

    [Header("Focus Settings")]
    [SerializeField]
    short focusGainOnKill;

    [Header("Auto Attack Settings")]
    [SerializeField]
    protected float autoAttackRange = 5.0f;
    [SerializeField]
    float autoAttackProjectileSpeed = 3.0f;
    [SerializeField]
    Projectile hunterAutoAttack;

    [Header("Hunter Snipe Settings")]
    [SerializeField]
    protected Projectile hunterSpecial;
    [SerializeField]
    short hunterSpecialCost = 5;
    [SerializeField]
    protected float specialAttackRange = 5.0f;
    [SerializeField]
    float specialAttackProjectileSpeed = 1.0f;


    float lastTick;

    public override bool AutoAttack()
    {

        if ((lastTick + autoAttackSpeed) <= Time.time)
        {
            lastTick = Time.time;
            Projectile p = Instantiate(hunterAutoAttack, transform.position + new Vector3(0, 1, 0), transform.rotation);
            float heading = Mathf.Atan2(CrossPlatformInputManager.GetAxis("Horizontal"), -CrossPlatformInputManager.GetAxis("Vertical"));
            Vector3 direction = Vector3.up; //Quaternion.Euler(0f, 0f, (((heading) * Mathf.Rad2Deg))).eulerAngles;

            p.Setup(direction, autoAttackProjectileSpeed, autoAttackRange, this);
            return true;
        }
        return false;
    }

    public override void HitEnemy(bool notDead)
    {
        if (!notDead)
        {
            EnemyKilled();
        }
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
            Projectile p = Instantiate(hunterSpecial, transform.position + new Vector3(0, 1, 0), transform.rotation);
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
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}
}
