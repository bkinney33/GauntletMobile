using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : Entity {

    [Tooltip("Upon death of the creature player will recieve this amount of score.")]
    [SerializeField]
    int scoreAwarded;
    [SerializeField]
    protected float autoAttackRange;
    protected GameObject collider;
    protected Transform target;
    protected IEnumerator TurnOffAttackCollider()
    {
        yield return new WaitForSeconds(autoAttackSpeed);
        collider.SetActive(false);
    }

    // Use this for initialization
    protected void Start () {
        collider = gameObject.transform.root.Find("AttackCollider").gameObject;
        collider.SetActive(false);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected void Update ()
    {
        if (target != null)
        {
            AttackPlayer();
        }
        else
        {
            FindPlayer();
        }
    }
    private void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void AttackPlayer()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (autoAttackRange >= distance)
        {
            AutoAttack();
        }
    }
}
