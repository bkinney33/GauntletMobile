using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rigidBody;
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
    public bool inRange;
    // Use this for initialization
    void Start()
    {

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(0.001f, 0);
        if (target == null) { return; }
        //if (IsInAggroRange())
        //{
        //    inRange = true;
        //    //self.LookAt(target);
        //    if (IsInMaxRange())
        //    {
        //        //self.position += self.up * moveSpeed * Time.deltaTime;
        //        inRange = false;
        //    }
        //if (Vector3.Distance(self.position, target.position) < minDist)
        //{
        //    self.position -= self.up * moveSpeed * Time.deltaTime;
        //    inRange = false;
        //}
    }
}
    //private bool IsInAggroRange()
    //{
    //    float dist = Vector3.Distance(self.position, target.position);
    //    return dist <= aggroRange ? true : false;
    //}
    //private bool IsInMaxRange()
    //{
    //    float dist = Vector3.Distance(self.position, target.position);
    //    return dist >= maxDist ? true : false;
    //}
