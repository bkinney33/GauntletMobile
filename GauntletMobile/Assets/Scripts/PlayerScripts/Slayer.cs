using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slayer : Class {

    [Tooltip("Amount of Energy Acquired per Enemy Hit.")]
    [SerializeField]
    short energyGainPerHit = 1;
    [Header("Poison Settings", order = 1)]
    GameObject poisonCover;
    [Tooltip("Energy Cost to Activate Poison Skill.")]
    [SerializeField]
    short poisonActivationCost;
    bool isPoisonActive = false;
    [Tooltip("Duration of Poison.")]
    [SerializeField]
    float poisonDuration;
    float poisonStartTime;
    double hpScale, timeScale;
    GameObject collider;
    private Animator animator;

    public override int GetDamage()
    {
        if (isPoisonActive) {
            hpScale = 2 - (currentHealth / maxHealth);
            float time = Time.time - poisonStartTime;
            timeScale = 2 - (time / poisonDuration);
            return (int)(damage * (hpScale + timeScale));
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
        animator.SetTrigger("autoAttack");
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
        if (isPoisonActive) { return false; }
        if(SpendResource(poisonActivationCost))
        {
            isPoisonActive = true;
            poisonStartTime = Time.time;
            poisonCover.SetActive(true);
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
        poisonCover.SetActive(false);
     }

    // Use this for initialization
    void Start () {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        collider = gameObject.transform.Find("AttackCollider").gameObject;
        poisonCover = gameObject.transform.Find("PoisonCover").gameObject;
        poisonCover.SetActive(false);
        collider.SetActive(false);
    }

    public override bool UpdateHealth(int change, UpdateType typeOfChange, bool showText)
    {
        return base.UpdateHealth(change, typeOfChange, showText);
    }

    public void EnemyKilled()
    {
    }

    public override void HitEnemy(bool notDead, Entity enemy)
    {
        GainResource(energyGainPerHit);
        if(isPoisonActive)
        {
            UpdateHealth((int)(damage *(hpScale+timeScale)), UpdateType.HEALING, true);
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
