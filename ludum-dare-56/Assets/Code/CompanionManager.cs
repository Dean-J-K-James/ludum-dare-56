using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionManager : MonoBehaviour
{
	public Image uiCompanionImage;
	public GameObject currentWeapon;

	// Update is called once per frame
	public void AddCompanion(Companion companion)
	{
		uiCompanionImage.sprite = companion.sprite;

		Destroy(currentWeapon);

		if (companion.weapon != null)
		{
			currentWeapon = Instantiate(companion.weapon, transform);
		}
	}
}
