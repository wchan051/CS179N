using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyline1 : MonoBehaviour
{
    string t1 = "ahh... where am i...";
    string t2 = "Wait, didn't I get hit by a car? \nAren't I dead??";
    string t3 = "This place looks a bit familiar. \nIt's almost like I'm in Sycamore Chronicles.";
    string t4 = "holy, is that a slime?? If this is what I think it\nis, I should train to level. Let's try to kill 5 \nslimes.";


	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	 bool done1 = false;
	 bool done2 = false;
	 bool done3 = false;
	public bool done4 = false;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowText(t1));
	}

	void Update()
	{
		/*if (Input.GetKeyDown("space"))
		{
			delay = 0.005f;
		}*/
		if(done4 && Input.GetKeyDown("space"))
        {
			this.GetComponent<Text>().text = "";
		}
		else if (done3 && Input.GetKeyDown("space"))
		{
			StartCoroutine(ShowText(t4));
		}
		else if (done2 && Input.GetKeyDown("space"))
		{
			StartCoroutine(ShowText(t3));
		}
		else if (done1 && Input.GetKeyDown("space"))
        {
			StartCoroutine(ShowText(t2));
		}
		
	}

	IEnumerator ShowText(string temp)
	{
		for (int i = 0; i < temp.Length; i++)
		{
			currentText = temp.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
		delay = 0.025f;
        if (!done4 && !done3 && !done2 && !done1)
		{
			done1 = true;
        }
		else if (!done4 && !done3 && !done2)
		{
			done2 = true;
		}
		else if (!done4 && !done3)
		{
			done3 = true;
		}
		else if (!done4)
		{
			done4 = true;
		}

	}
}
