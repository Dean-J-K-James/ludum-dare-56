using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public Transform player;
    public Sprite sprite;
    public GameObject weapon;
    public string colourName;

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
            FindFirstObjectByType<CompanionManager>().AddCompanion(this);
            Destroy(gameObject);
        }
    }
}
