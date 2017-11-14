using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceManager))]
public abstract class Class : Entity {
    
    [SerializeField]
    protected double maxClassResource;
    protected double currentClassResource;
    [SerializeField]
    string className;

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
        throw new NotImplementedException();
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


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
