using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyOnCollision : MonoBehaviour
{
    public bool destroyOnCollision = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet trigger");

        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.DamageEnemy();

            if (destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}
