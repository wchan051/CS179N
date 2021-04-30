using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{

	public Slider slider;

	public void SetMaxXp(int Xp) {
		slider.maxValue = Xp;
		slider.value = 0;
	}

    public void SetXp(int Xp) {
		slider.value = Xp;
	}

	public float GetXp() {
		return slider.value;
	}

}