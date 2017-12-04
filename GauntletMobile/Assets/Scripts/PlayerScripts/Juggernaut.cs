using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Juggernaut : Class {
    bool isInvincible = false;
    [Header("Rage Settings", order = 1)]
    [Tooltip("Cost to rage per second. Base values indicate the player must kill a creature once every 5 seconds to maintain rage.")]
    [SerializeField]
    short rageCostPerSecond = 1;
    [Tooltip("HP regened per second inside rage.")]
    [SerializeField]
    short hpRegen = 1;
    [Tooltip("Limiter on rage gain per kill increasing or decreasing this value without editing rage cost will change the ease of maintaining rage.")]
    [SerializeField]
    short rageGainOnKill = 5;
    float lastTick;
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        base.Start();
    }

    public override bool AutoAttack()
    {
        
        Debug.Log("Auto On.");
        GameObject collider = gameObject.transform.Find("AttackCollider").gameObject;
        collider.SetActive(true);
        animator.SetTrigger("autoAttack");
        StartCoroutine(TurnOffAttackCollider());

        return true;
    }

    IEnumerator TurnOffAttackCollider()
    {
        yield return new WaitForSeconds(autoAttackSpeed);
        GameObject collider = gameObject.transform.Find("AttackCollider").gameObject;
        collider.SetActive(false);
        Debug.Log("Auto Off.");
    }

    public override bool SpecialSkill()
    {
        Debug.Log("Special Skill");
        isInvincible = !isInvincible;
        lastTick = Time.time;
        return true;
    }
     
    // Use this for initialization
 
    public override bool UpdateHealth(int change, UpdateType typeOfChange)
    {
        if(change < 0 && isInvincible)
        {
            return true;
        }
       return base.UpdateHealth(change, typeOfChange);        
    }

    public override void HitEnemy(bool notDead, Entity enemy)
    {
        if (!notDead)
        {
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        GainResource(rageGainOnKill);
    }

    // Update is called once per frame
    void Update () {
        base.Update();
        if (isInvincible) { WhileRaging(); }

    }

    private void WhileRaging()
    {

        if((lastTick + 1) <= Time.time)
        {
            if (!SpendResource(rageCostPerSecond))
            {
                isInvincible = false;
            }
            UpdateHealth(hpRegen, UpdateType.HEALING);
            lastTick = Time.time;
        }

    }
}
