using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item {

    [SerializeField]
    int healthRecovered;

    public override bool Use()
    {
        throw new NotImplementedException();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
