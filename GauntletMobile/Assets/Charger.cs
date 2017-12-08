using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Charger : Mob
{
    [Header("Charge Settings")]
    [SerializeField]
    float interval;
    [Tooltip("Max distance creature can travel at one time.")]
    [SerializeField]
    float range;
    [Tooltip("Max range from point of spawn the creater is allowed to travel")]
    [SerializeField]
    float ContainedRange;
    [SerializeField]
    float chargeSpeed;
    [SerializeField]
    Rigidbody2D rigidBody;
    [SerializeField]
    float stunDurationOnHit;
    private Transform self;
    private Vector2 lastPosition;
    private Vector2 startPosition;
    float lastTick;
    // Use this for initialization
    void Start()
    {
        base.Start();
        self = gameObject.transform.root;
        lastTick = Time.time;
        lastPosition = self.position;
        startPosition = lastPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(interval + lastTick < Time.time)
        {
            AutoAttack();
            lastTick = Time.time;
        }
        if (PositionCheck())
        {
            rigidBody.velocity = new Vector2(0, 0);
            collider.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
       
        Vector2 position = new Vector2(self.position.x, self.position.y) + rigidBody.velocity;
        float d = Vector2.Distance(startPosition, position);
        if(d > ContainedRange)
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    private bool PositionCheck()
    {
        float r = Vector2.Distance(lastPosition, self.position);
        bool res = (r >= range) ? true : false;
        return res;
    }

    public override void HitEnemy(bool deadEnemy, Entity enemy)
    {
        enemy.StunMe(stunDurationOnHit);
    }

    public override bool AutoAttack()
    {
        Vector2 position = UnityEngine.Random.insideUnitCircle;
        self.LookAt(new Vector3(position.x, position.y) + self.position);
        float y = self.rotation.eulerAngles.y;
        self.Rotate(new Vector3(0, 1, 0), -y);
        rigidBody.velocity = position * chargeSpeed;
        lastPosition = self.position;
        collider.SetActive(true);
        return true;
    }
}
