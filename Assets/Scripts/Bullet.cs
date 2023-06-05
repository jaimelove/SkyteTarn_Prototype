using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 dir;
    private float velocity;

    public void Setup(Vector2 dir, float velocity)
    {
        this.dir = dir;
        this.velocity = velocity;

        rb.velocity = velocity * dir.normalized;
    }
}
