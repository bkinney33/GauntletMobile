using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceManager))]
public abstract class Class : Entity {
    
    [SerializeField]
    double maxClassResource;
    double currentClassResource;
    [SerializeField]
    string className;

    public abstract bool SpecialAttack();

    override
    public void UpdateHealth(int change)
    {
        currentHealth += change;
        gameObject.GetComponent<ResourceManager>().UpdateHealth(currentHealth / maxHealth);
    }
    public void UpdateResource(int change)
    {
        currentClassResource += change;
        gameObject.GetComponent<ResourceManager>().UpdateMana(currentClassResource / maxClassResource);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
