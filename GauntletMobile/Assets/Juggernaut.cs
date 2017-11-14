using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Juggernaut : Class {
    public bool isInvincible = false;
    [Tooltip("Cost to rage per second. Base values indicate the player must kill a creature once every 5 seconds to maintain rage.")]
    [SerializeField]
    short rageCostPerSecond = 1;
    [SerializeField]
    [Tooltip("Limiter on rage gain per kill increasing or decreasing this value without editing rage cost will change the ease of maintaining rage.")]
    short rageGainOnKill = 5;
    public float lastTick;

    public override bool AutoAttack()
    {
        throw new NotImplementedException();
    }

    public override bool SpecialSkill()
    {
        Debug.Log("Special Skill");
        isInvincible = !isInvincible;
        lastTick = Time.time;
        return true;
    }
     
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        currentClassResource = maxClassResource;
    }

    public override void UpdateHealth(int change, UpdateType typeOfChange)
    {
        if(change < 0 && isInvincible)
        {
            return;
        }
        base.UpdateHealth(change, typeOfChange);        
    }

    public void EnemyKilled()
    {
        GainResource(rageGainOnKill);
    }

    // Update is called once per frame
    void Update () {
        if (isInvincible) { WhileRaging(); }
        if(Input.GetButtonUp("SpecialSkill"))
        {
            SpecialSkill();
        }
    }

    private void WhileRaging()
    {

        if((lastTick + 1) <= Time.time)
        {
            if (!SpendResource(rageCostPerSecond))
            {
                isInvincible = false;
            }
            lastTick = Time.time;
        }

    }
}
