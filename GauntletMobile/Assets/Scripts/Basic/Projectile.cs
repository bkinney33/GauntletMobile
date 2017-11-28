using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    float projectileSpeed;
    float projectileRange;
    public Vector2 startPosition;

    public Projectile(float range, int damage)
    {
        projectileRange = range;
    }

    internal void Setup(Vector3 direction, float speed, float range, Entity parent)
    {
        projectileRange = range;
        projectileSpeed = speed;
        transform.Rotate(direction);
        gameObject.GetComponent<Rigidbody2D>().velocity = direction*projectileSpeed;
        Debug.Log(direction);
        damageCollider collider = gameObject.GetComponentInChildren<damageCollider>();
        if (collider == null)
        {
            Debug.Log("Damage Collider = Null on Projectile.");
        }
        else
        {
            collider.SetParent(parent);
        }
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, startPosition);
        if(distance >= projectileRange)
        {
            Destroy(gameObject);
        }
    }
}