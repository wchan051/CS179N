using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opTextScript : MonoBehaviour
{
	
        string intro = "pov ur a 24 y/o software engineer \n\n" +
			"after work you see a girl getting robbed and you run across \n" +
			"the street to help\n\n" + "u get hit by a taxi\n\n" + "...\n\n" +
			"you wake up and find yourself in a strange new world";


	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i < intro.Length; i++)
		{
			currentText = intro.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
