using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        //{
        //    //Arrived at target, so deal damage.
        //    var enemy = target.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.DamageEnemy();
        //    }
        //    Destroy(gameObject);
        //}
    }
}
