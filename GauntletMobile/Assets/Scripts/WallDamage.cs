using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamage : MonoBehaviour {

    [SerializeField]
    int damage;
    [SerializeField]
    float interval;

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject g = collision.transform.root.gameObject;
        Entity e = g.gameObject.GetComponentInChildren<Entity>();
        if (e != null)
        {
            if (e.wallDamageTick + interval < Time.time)
            {
                e.wallDamageTick = Time.time;
                e.UpdateHealth(damage, Entity.UpdateType.DAMAGE, true);
            }
        }
    }
}
