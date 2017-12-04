using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slayer : Class {

    [Tooltip("Amount of Energy Acquired per Enemy Hit.")]
    [SerializeField]
    short energyGainPerHit = 1;
    [Header("Poison Settings", order = 1)]
    [Tooltip("Energy Cost to Activate Poison Skill.")]
    [SerializeField]
    short poisonActivationCost;
    bool isPoisonActive = false;
    [Tooltip("Duration of Poison.")]
    [SerializeField]
    float poisonDuration;
    float poisonStartTime;
    GameObject collider;

    public override int GetDamage()
    {
        if (isPoisonActive) {
            float hpScale = 2 - (currentHealth / MaxHealth);
            float time = Time.time - poisonStartTime;
            float timeScale = 2 - (time / poisonDuration);
            return damage * (hpScale + timeScale);
        }
        else
        {
            return damage;
        }
    }

    public override bool AutoAttack()
    {
        Debug.Log("Auto On.");
        collider.SetActive(true);
        StartCoroutine(TurnOffAttackCollider());
        return true;
    }

    IEnumerator TurnOffAttackCollider()
    {
        yield return new WaitForSeconds(autoAttackSpeed);
        collider.SetActive(false);
        Debug.Log("Auto Off.");
    }

    public override bool SpecialSkill()
    {
        if(SpendResource(poisonActivationCost))
        {
            isPoisonActive = true;
            poisonStartTime = Time.time;
            StartCoroutine(PoisonSkill());
            return true;
        }
        return false;
    }

    IEnumerator PoisonSkill()
    {
        yield return new WaitForSeconds(poisonDuration);
        TurnOffPoisonEffects(); 
    }

    private void TurnOffPoisonEffects()
    {
        isPoisonActive = false;
     }

    // Use this for initialization
    void Start () {
        base.Start();
        collider = gameObject.transform.Find("AttackCollider").gameObject;

    }

    public override bool UpdateHealth(int change, UpdateType typeOfChange)
    {
        return base.UpdateHealth(change, typeOfChange);
    }

    public void EnemyKilled()
    {
    }

    public override void HitEnemy(bool notDead, Entity enemy)
    {
        GainResource(energyGainPerHit);
        if(isPoisonActive)
        {
            UpdateHealth(damage, UpdateType.HEALING);
        }
        isPoisonActive = false;
        if(!notDead)
        {
            EnemyKilled();
        }
    }

    // Update is called once per frame
    void Update () {
        base.Update();
    }
}
