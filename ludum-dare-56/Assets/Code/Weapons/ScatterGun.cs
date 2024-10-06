using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterGun : MonoBehaviour
{
	public Transform player;
	public BulletDirectional bullet; //

	float combatTimer;



	void Start()
	{
		player = FindFirstObjectByType<Player>().transform;
	}

	void Update()
	{
		combatTimer += Time.deltaTime;

		if (combatTimer >= 0.75f)
		{
			combatTimer = 0;

			var angle = Random.Range(0, 360);

			var newx = player.position.x + (5f * Mathf.Cos(angle));
			var newy = player.position.y + (5f * Mathf.Sin(angle));

			Debug.Log(angle);

			CreateBullet(new Vector3(newx, newy));
		}

	}

	void CreateBullet(Vector3 target)
	{
		var b = Instantiate(bullet);

		Debug.Log("Creating bullet with target: " + target);

		b.transform.position = player.position;
		b.target = target;
	}
}
