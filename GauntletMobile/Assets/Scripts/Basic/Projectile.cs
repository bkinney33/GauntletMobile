using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float projectileSpeed;
    float projectileRange;
    public Vector2 startPosition;
    Rigidbody2D m_rigidBody;



    internal void Setup(Vector2 direction, float speed, float range, Entity parent)
    {
        startPosition = transform.position;
        projectileRange = range;
        projectileSpeed = speed;
        m_rigidBody.velocity = direction * projectileSpeed;
        damageCollider collider = gameObject.GetComponent<damageCollider>();
        if (collider == null)
        {
            Debug.Log("Damage Collider = Null on Projectile.");
        }
        else
        {
            collider.SetParent(parent);
        }
    }

    private void Awake()
    {
        startPosition = transform.position;
        m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, startPosition);
        if (distance >= projectileRange)
        {
            gameObject.SetActive(false);
        }
    }
}