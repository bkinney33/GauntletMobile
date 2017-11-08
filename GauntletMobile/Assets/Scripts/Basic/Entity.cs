using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    [SerializeField]
    int health;
    [SerializeField]
    int damage;
    [Tooltip("If Entity uses projectiles this range will be sent to the projectile")]
    [SerializeField]
    float attackRange;
    [Tooltip("Leave empty if the entity does not use projectiles")]
    [SerializeField]
    Projectile projectile;

    public abstract bool AutoAttack();
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
