using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceManager))]
public abstract class Class : Entity {
    
    [Header("Resource Settings", order = 2)]
    [SerializeField]
    protected double maxClassResource;
    public double currentClassResource;

    public abstract bool SpecialSkill();

    override
    public void UpdateHealth(int change, UpdateType typeOfChange)
    {
        base.UpdateHealth(change, typeOfChange);
        gameObject.GetComponent<ResourceManager>().UpdateHealth(currentHealth / maxHealth);
    }

    override
    public void Die()
    {

        Debug.Log("How");

    }

    public bool SpendResource(int change)
    {
        if (currentClassResource - change < 0)
        {
            return false;
        }
        else
        {
            currentClassResource -= change;
            gameObject.GetComponent<ResourceManager>().UpdateMana(currentClassResource / maxClassResource);
            return true;
        }
    }
    public void GainResource(int change)
    {
        currentClassResource += change;
        if(currentClassResource > maxClassResource) { currentClassResource = maxClassResource; }
        gameObject.GetComponent<ResourceManager>().UpdateMana(currentClassResource / maxClassResource);
    }

    protected void Start()
    {
        currentHealth = maxHealth;
        currentClassResource = maxClassResource;
    }

    internal void Update()
    {
        if (Input.GetButtonUp("SpecialSkill"))
        {
            SpecialSkill();
        }
        if (Input.GetButtonUp("AutoAttack"))
        {
            AutoAttack();
        }
    }
}
