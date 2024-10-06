using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public Enemy[] enemies;
    public float timer;
    int enemyCount = 0;
    public float waveDelay = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        waveDelay -= (Time.deltaTime / 250f);
        waveDelay = Mathf.Clamp(waveDelay, 0.25f, 1.25f);
        timer += Time.deltaTime;

        if (timer > waveDelay)
        {
            timer = 0f;

            var e = Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
            e.name = "enemy-" + enemyCount++;

            var angle = Random.Range(0, 360);

            var newx = player.position.x + (10f * Mathf.Cos(angle));
            var newy = player.position.y + (10f * Mathf.Sin(angle));

            e.transform.position = new Vector2(newx, newy);
        }
    }
}
