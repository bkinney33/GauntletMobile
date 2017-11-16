using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCollider : MonoBehaviour {

    [SerializeField]
    Entity parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject.transform.parent.gameObject;
        Entity e = g.GetComponentInChildren<Entity>();
        e.UpdateHealth(parent.GetDamage(), Entity.UpdateType.DAMAGE);
        parent.HitEnemy();
    }


}
