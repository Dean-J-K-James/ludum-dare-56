using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartFrog : MonoBehaviour
{
    public Transform player;
    public Bullet bullet; //
    float combatTimer;



    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        combatTimer += Time.deltaTime;

        if (combatTimer >= 1)
        {
            combatTimer = 0;

            var closestEnemy = GetClosestEnemy();

            if (closestEnemy != null)
            {
                Debug.Log("Closest enemy: " + closestEnemy + " with distance: " + Vector2.Distance(player.position, closestEnemy.transform.position));

                if (Vector2.Distance(player.position, closestEnemy.transform.position) <= 8f)
                {
                    Debug.Log("Spawning bullet");
                    var b = Instantiate(bullet);

                    b.transform.position = player.position;
                    b.target = closestEnemy.transform;
                }


            }
        }
    }


    Enemy GetClosestEnemy()
    {
        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        if (enemies.Length == 0)
        {
            return null;
        }

        Enemy closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            var dist = Vector2.Distance(player.position, enemy.transform.position);

            if (dist < closestDistance)
            {
                closest = enemy;
                closestDistance = dist;
            }
        }

        return closest;
    }
}
