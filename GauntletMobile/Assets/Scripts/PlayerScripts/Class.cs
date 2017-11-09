using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Class : Entity {
    
    [SerializeField]
    int classResource;
    [SerializeField]
    string className;

    public abstract bool SpecialAttack();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
