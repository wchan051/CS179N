using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{
    public GameObject t;
    public bool typing = false;
    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.Find("Text");
        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        typing = t.GetComponent<storyline1>().typing;
        if (typing)
        {
            GetComponent<SpriteRenderer>().color =  new Color(1f, 1f, 1f, .45f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
