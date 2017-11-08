using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    Transform target;
    [Tooltip("Minimum distance needed to be able to hit player.")]
    [SerializeField]
    float minDist;
    [Tooltip("Max distance at which enemy can hit player. Primarily used by ranged enemies.")]
    [SerializeField]
    float maxDist;
    [Tooltip("Range at which enemies will take action against the player.")]
    [SerializeField]
    float aggroRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.LookAt(target);
        if(Vector3.Distance(transform.position, target.position) <= aggroRange)
        {

        }


	}
}
