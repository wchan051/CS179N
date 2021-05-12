using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dtrigger : MonoBehaviour
{
    public Dialogue dialogue;
	public void TriggerDialogue()
	{
		FindObjectOfType<dmanager>().StartDialogue(dialogue);
	}
}
