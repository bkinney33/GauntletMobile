using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingCollider : damageCollider {

    [Tooltip("Check this box if entities should stop the object from moving.")]
    [SerializeField]
    bool entityCollision;
    [Tooltip("Check this box if the collider should pass through all objects")]
    [SerializeField]
    bool phantomCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject g = collision.gameObject.transform.parent.gameObject;
        Entity e = g.GetComponentInChildren<Entity>();
        if (e != null)
        {
            bool notDead = e.UpdateHealth(parent.GetDamage(), Entity.UpdateType.DAMAGE);
            parent.HitEnemy(notDead);
        }

        if (oneTimeUse)
        {
            if(e != null && entityCollision) { return; }
            if (phantomCollision) { return; }
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
