using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed = 5f;

    void Start()
    {
        FindFirstObjectByType<PlayerHealth>().UpdateHealthUI(health);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }

        movement.Normalize();
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }

    public void DamagePlayer()
    {
        health--;
        FindFirstObjectByType<PlayerHealth>().UpdateHealthUI(health);
    }
}
