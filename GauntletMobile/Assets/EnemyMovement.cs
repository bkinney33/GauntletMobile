using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Tooltip("Allows us to toss this onto the brain of an enemy.")]
    [SerializeField]
    Transform self;
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
    [Tooltip("How fast an enemy can travel")]
    [SerializeField]
    float moveSpeed;
    bool inRange;
    // Use this for initialization
    void Start () {

        //set target to player
        target = GameObject.Find("Player").transform;
	}

    // Update is called once per frame
    void Update()
    {
        if (IsInAggroRange())
        {
            inRange = true;
            self.LookAt(target);
            if (IsInMaxRange())
            {
                self.position += self.forward * moveSpeed * Time.deltaTime;
                inRange = false;
            }
            if (Vector3.Distance(self.position, target.position) < minDist)
            {
                self.position -= self.forward * moveSpeed * Time.deltaTime;
                inRange = false;
            }
        }
    }
    private bool IsInAggroRange()
    {
        float dist = Vector3.Distance(self.position, target.position);
        Debug.Log("Aggro Range Function: Current Range: " + dist);
        return dist <= aggroRange ? true : false;
    }
    private bool IsInMaxRange()
    {
        float dist = Vector3.Distance(self.position, target.position);
        return dist >= maxDist ? true : false;
    }
}
