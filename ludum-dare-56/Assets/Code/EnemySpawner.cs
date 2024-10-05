using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public Enemy enemy;
    public float timer;
    int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2.5f)
        {
            timer = 0f;

            var e = Instantiate(enemy, transform);
            e.name = "enemy-" + enemyCount++;

            var angle = Random.Range(0, 360);

            var newx = player.position.x + (20f * Mathf.Cos(angle));
            var newy = player.position.y + (20f * Mathf.Sin(angle));

            e.transform.position = new Vector2(newx, newy);
        }
    }
}
