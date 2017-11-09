using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : Entity {

    [Tooltip("Upon death of the creature player will recieve this amount of score.")]
    [SerializeField]
    int scoreAwarded;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
