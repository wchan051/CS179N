using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slimeHealthText : MonoBehaviour
{
    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.transform.localScale == new Vector3(-3.0f, 3.0f, 1.0f)) {
            this.GetComponent<Text>().text = slime.GetComponent<slimeScript>().health.ToString();
            transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
            transform.position = slime.transform.position + new Vector3 (6.8f,0,0);    
        }
        else {
            transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
            this.GetComponent<Text>().text = slime.GetComponent<slimeScript>().health.ToString();
            transform.position = slime.transform.position + new Vector3 (9.8f,0,0);
        }
    }
}
