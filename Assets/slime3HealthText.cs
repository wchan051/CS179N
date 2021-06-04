using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slime3HealthText : MonoBehaviour
{
    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.transform.localScale == new Vector3(-20.0f, 20.0f, 1.0f)) {
            this.GetComponent<Text>().text = slime.GetComponent<slime3>().health.ToString();
            transform.localScale = new Vector3 (-0.5f, .5f, 1.0f);
            transform.position = slime.transform.position + new Vector3 (22.8f,0,0);    
        }
        else {
            transform.localScale = new Vector3 (.5f, .5f, 1.0f);
            this.GetComponent<Text>().text = slime.GetComponent<slime3>().health.ToString();
            transform.position = slime.transform.position + new Vector3 (43.8f,0,0);
        }
    }
}
