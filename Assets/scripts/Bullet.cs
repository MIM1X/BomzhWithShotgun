using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
