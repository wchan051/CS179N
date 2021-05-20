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
        this.GetComponent<Text>().text = slime.GetComponent<slimeScript>().health.ToString();
        transform.position = slime.transform.position + new Vector3 (8f,0,0);
        
    }
}
