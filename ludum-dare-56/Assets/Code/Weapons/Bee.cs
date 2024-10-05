using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Transform player;
    public float speed = 100f;
    public float angle;

    void Start()
    {
        player = FindFirstObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + Quaternion.AngleAxis(angle += speed * Time.deltaTime, player.transform.forward) * new Vector3(2.5f, 0f, 0f);
    }
}
