using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
	public Transform player;
	Vector3 direction;
	public float speed;

	void Start()
	{
		player = FindFirstObjectByType<Player>().transform;
		direction = player.position - transform.position;
		direction.Normalize();
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void Update()
	{
		if (Vector2.Distance(transform.position, player.position) <= 1f)
		{
			player.GetComponent<Player>().DamagePlayer();
			Destroy(gameObject);
		}
		else if (Vector2.Distance(transform.position, player.position) >= 25f)
		{
			Destroy(gameObject);
		}
	}
}
