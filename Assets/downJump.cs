using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class downJump : MonoBehaviour
{
    public bool onCollider ;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.DownArrow))
            {
                onCollider = true;
                platform.GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }

    void OnTriggerExit2d(Collider2D other)
    {
        if (other.tag == "Player")
        {

            
                platform.GetComponent<TilemapCollider2D>().enabled = true;
            
        }
    }
}
