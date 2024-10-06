using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    public TextMeshProUGUI damageText;
    public Canvas worldUI;

    public void CreateDamageText(float x, float y)
    {
        var text = Instantiate(damageText, worldUI.transform);
        text.transform.position = new Vector2(x, y);
    }
}
