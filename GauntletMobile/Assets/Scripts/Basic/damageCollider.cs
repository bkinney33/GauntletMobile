﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCollider : MonoBehaviour
{

    [Header("Collision Settings")]
    [SerializeField]
    protected Entity parent;
    [SerializeField]
    protected bool oneTimeUse = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("attack");
        if(collision.gameObject.layer == 12)
        {
            return;
        }
        GameObject g = collision.gameObject.transform.root.gameObject;
        Entity e = g.GetComponentInChildren<Entity>();
        if (e != null)
        {
            Debug.Log("Entity: " + e.name + " Parent: " + parent.name);
            bool notDead = e.UpdateHealth(parent.GetDamage(), Entity.UpdateType.DAMAGE, true);
            parent.HitEnemy(notDead, e);
        }
        if (oneTimeUse)
        {
            transform.root.gameObject.SetActive(false);
            Debug.Log("Projectile Deactivated");
        }
    }

    internal void SetParent(Entity parent)
    {
        this.parent = parent;
    }
}
