using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
	public Transform player;
	public float speed;

	void Start()
	{
		player = FindFirstObjectByType<Player>().transform;
	}

	void Update()
	{
		Vector3 direction = player.position - transform.position;
		direction.Normalize();
		GetComponent<Rigidbody2D>().velocity = direction * speed;

		if (Vector2.Distance(transform.position, player.position) <= 1f)
		{
			player.GetComponent<Player>().DamagePlayer();
			Destroy(gameObject);
		}
	}
}
