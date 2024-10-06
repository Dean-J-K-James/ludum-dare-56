using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGun : MonoBehaviour
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

			CreateBullet(new Vector3(4.0f, 0.0f));
			CreateBullet(new Vector3(4.0f, 4.0f));
			CreateBullet(new Vector3(0.0f, 4.0f));
			CreateBullet(new Vector3(-4.0f, 4.0f));
			CreateBullet(new Vector3(-4.0f, 0.0f));
			CreateBullet(new Vector3(-4.0f, -4.0f));
			CreateBullet(new Vector3(0.0f, -4.0f));
			CreateBullet(new Vector3(4.0f, -4.0f));
		}

	}

	void CreateBullet(Vector3 target)
	{
		var b = Instantiate(bullet);

		b.transform.position = player.position;
		b.target = player.position + target;
	}
}
