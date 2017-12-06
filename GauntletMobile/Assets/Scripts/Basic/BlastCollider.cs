using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastCollider : damageCollider {

    [SerializeField]
    float radius;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(collision.transform.position, radius);

        foreach(Collider2D x in hitColliders)
        {
            GameObject g = x.gameObject.transform.parent.gameObject;
            Entity e = g.GetComponentInChildren<Entity>();
            if (e != null)
            {
                bool notDead = e.UpdateHealth(parent.GetDamage(), Entity.UpdateType.DAMAGE, true);
                parent.HitEnemy(notDead, e, true);
            }
        }

        if (oneTimeUse)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
