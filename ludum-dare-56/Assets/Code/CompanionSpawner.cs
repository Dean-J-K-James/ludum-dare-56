using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CompanionSpawner : MonoBehaviour
{
	public List<GameObject> companions;
	float timer = 25f;

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= 15f)
		{
			timer = 0f;
			PlaceCompanion();
			//Debug.Log("Companion has been placed");
		}
	}

	void PlaceCompanion()
	{
		var world = GetComponent<WorldGenerator>();

		var bounds = world.tilemap.localBounds;

		var minx = Mathf.RoundToInt(bounds.min.x);
		var miny = Mathf.RoundToInt(bounds.min.y);
		var maxx = Mathf.RoundToInt(bounds.max.x);
		var maxy = Mathf.RoundToInt(bounds.max.y);

		bool placed = false;

		var companionToPlace = companions[Random.Range(0, companions.Count)];

		while (placed == false)
		{
			int tryx = Random.Range(minx, maxx);
			int tryy = Random.Range(miny, maxy);

			if (world.tilemap.GetTile(new Vector3Int(tryx, tryy, 0)) == world.path)
			{
				var c = Instantiate(companionToPlace);
				c.transform.position = new Vector2(tryx, tryy);
				placed = true;
			}
		}
	}
}
