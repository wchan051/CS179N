using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class opTextScript : MonoBehaviour
{
	
        string intro = "pov ur a 24 y/o videogame programmer \n\n" +
			"after work you see a girl getting robbed and you run across \n" +
			"the street to help\n\n" + "u get hit by a taxi\n\n" + "...\n\n" +
			"you wake up and find yourself in a strange new world";


	public float delay = 0.025f;
	public string fullText;
	private string currentText = "";
	bool done = false;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowText());
	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			delay = 0.005f;
		}
        if (done && Input.GetKeyDown("space"))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i < intro.Length; i++)
		{
			currentText = intro.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
		done = true;
	}
}
