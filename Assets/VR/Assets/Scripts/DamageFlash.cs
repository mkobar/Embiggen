using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour {
	public CanvasGroup canGroup;
	private bool flash = false;

	void Start(){
	}

	void Update ()
	{
		if (flash)
		{
			canGroup.alpha = canGroup.alpha - Time.deltaTime;
			if (canGroup.alpha <= 0)
			{
				canGroup.alpha = 0;
				flash = false;
			}
		}
	}

	public void damage ()
	{
		flash = true;
		canGroup.alpha = 1;
	}
}