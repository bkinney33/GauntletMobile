﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ResourceManager))]
public abstract class Class : Entity {
    
    [Header("Resource Settings", order = 2)]
    [SerializeField]
    protected double maxClassResource;
    public double currentClassResource;

    public abstract bool SpecialSkill();

    override
    public bool UpdateHealth(int change, UpdateType typeOfChange, bool showText)
    {
        bool val = base.UpdateHealth(change, typeOfChange, showText);
        gameObject.GetComponent<ResourceManager>().UpdateHealth(currentHealth / maxHealth);
        return val;
    }

    override
    public void Die()
    {

        Debug.Log("How");
        SceneManager.LoadScene("GameOver");

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

    public void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("SpecialSkill"))
        {
            SpecialSkill();
        }
        if (CrossPlatformInputManager.GetButtonUp("AutoAttack"))
        {
            AutoAttack();
        }
    }
}
