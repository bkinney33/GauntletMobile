using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCollider : MonoBehaviour {

    [Header("Collision Settings")]
    [SerializeField]
    protected Entity parent;
    [SerializeField]
    protected bool oneTimeUse = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject g = collision.gameObject.transform.parent.gameObject;
        Entity e = g.GetComponentInChildren<Entity>();
        if (e != null)
        {
            bool notDead = e.UpdateHealth(parent.GetDamage(), Entity.UpdateType.DAMAGE);
            parent.HitEnemy(notDead);
        }
        if(oneTimeUse)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    internal void SetParent(Entity parent)
    {
        this.parent = parent;
    }
}
