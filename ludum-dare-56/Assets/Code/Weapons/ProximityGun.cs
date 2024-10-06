using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityGun : MonoBehaviour
{
	public Transform player;
	float combatTimer;



	void Start()
	{
		player = FindFirstObjectByType<Player>().transform;
	}

	void Update()
	{
		combatTimer += Time.deltaTime;

		if (combatTimer >= 2)
		{
			combatTimer = 0;

			var enemies = Physics2D.OverlapCircleAll(player.position, 2.5f);

			foreach (var enemy in enemies)
			{
				if (enemy.GetComponent<Enemy>() != null)
				{
					enemy.GetComponent<Enemy>().DamageEnemy();
				}
			}
		}

	}
}
