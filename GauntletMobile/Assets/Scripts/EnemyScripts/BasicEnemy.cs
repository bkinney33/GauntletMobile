using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Mob {

    // Use this for initialization
    void Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
        base.Update();
	}

    public override bool AutoAttack()
    {
        collider.SetActive(true);
        StartCoroutine(TurnOffAttackCollider());
        return true;
    }
}
