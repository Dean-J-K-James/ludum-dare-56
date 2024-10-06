using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
	public TextMeshProUGUI damageText;
    float opacity = 1f;

    // Update is called once per frame
    void Update()
    {
        opacity -= Time.deltaTime * 2.5f;

        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, opacity);

        if (opacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
