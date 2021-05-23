using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyline1 : MonoBehaviour
{
	bool showingText = false;
    string t1 = "ahh... where am i...";
    string t2 = "Wait, didn't I get hit by a car? \nAren't I dead??";
    string t3 = "This place looks a bit familiar. \nIt's almost like I'm in Sycamore Chronicles.";
    string t4 = "holy, is that a slime?? If this is what I think it\nis, I should train to level. Let's try to kill 5 \nslimes.";

	public bool typing = false;

	public float delay = 0.1f;
	public string fullText;
	private string currentText = "";
	 int done1 = 0;
	 int done2 = 0;
	 int done3 = 0;
	 public int done4 = 0;

	// Use this for initialization
	void Start()
	{
		done1 = PlayerPrefs.GetInt("done1");
		done2 = PlayerPrefs.GetInt("done2");
		done3 = PlayerPrefs.GetInt("done3");
		done4 = PlayerPrefs.GetInt("done4");

		if (done1 == 0) { StartCoroutine(ShowText(t1)); typing = true; }
		else if (done2 == 0) { StartCoroutine(ShowText(t2)); typing = true; }
		else if (done3 == 0) { StartCoroutine(ShowText(t3)); typing = true; }
		else if (done4 == 0) { StartCoroutine(ShowText(t4)); typing = true; }
	}

	void Update()
	{
        /*if (Input.GetKeyDown("space"))
		{
			delay = 0.005f;
		}*/
        if (!showingText) { 
			if(done4 ==1 && Input.GetKeyDown(KeyCode.Return))
			{
				this.GetComponent<Text>().text = "";
				typing = false;
			}
			else if (done3 == 1 && Input.GetKeyDown(KeyCode.Return))
			{
				StartCoroutine(ShowText(t4));
			}
			else if (done2 == 1 && Input.GetKeyDown(KeyCode.Return))
			{
				StartCoroutine(ShowText(t3));
			}
			else if (done1 == 1 && Input.GetKeyDown(KeyCode.Return))
			{
				StartCoroutine(ShowText(t2));
			}
		}

        
	}

	IEnumerator ShowText(string temp)
	{
		showingText = true;
		for (int i = 0; i < temp.Length; i++)
		{
			currentText = temp.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
		delay = 0.025f;
        if (done4==0 && done3 == 0 && done2 == 0 && done1 == 0)
		{
			done1 = 1;
			PlayerPrefs.SetInt("done1", 1);
		}
		else if (done4 == 0 && done3 == 0 && done2 == 0)
		{
			done2 = 1;
			PlayerPrefs.SetInt("done2", 1);
		}
		else if (done4 == 0 && done3 == 0)
		{
			done3 = 1;
			PlayerPrefs.SetInt("done3", 1);
		}
		else if (done4 == 0)
		{
			done4 = 1;
			PlayerPrefs.SetInt("done4", 1);
			
		}
		showingText = false;
	}
}
