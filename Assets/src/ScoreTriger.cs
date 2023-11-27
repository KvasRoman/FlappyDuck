using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ScoreTriger : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D collider2D;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }
    public void SetVelocity(float velocity)
    {
        rb2d.velocity = new Vector2(-velocity, 0);
    }
}
