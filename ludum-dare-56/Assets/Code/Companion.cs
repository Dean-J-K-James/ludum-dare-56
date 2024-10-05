using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Vector2.Distance(transform.position, player.position) * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) <= 1f)
        {
            //Add this companion to the player's roster.
            Destroy(gameObject);
        }
    }
}
