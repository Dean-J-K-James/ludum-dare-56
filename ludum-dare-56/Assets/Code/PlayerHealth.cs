using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] hearts;

    public void UpdateHealthUI(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health);
        }
    }
}
