using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;

    public void DamageEnemy()
    {
        health--;
        FindFirstObjectByType<DamageTextManager>().CreateDamageText(transform.position.x, transform.position.y);

        if (health <= 0)
        {
            FindFirstObjectByType<ScoreManager>().AddScore();
			Destroy(gameObject);
        }
    }
}
