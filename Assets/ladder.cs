using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ladder : MonoBehaviour
{
    public float speed;
    public bool onstay = false;
    Collider2D c;

    // Start is called before the first frame update
    void Start()
    {
        //Collider2D.friction = 0;
        c = GetComponent<Collider2D>();
        c.enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            c.enabled = true;
        }
        else if(!onstay)
        {
            c.enabled = false;
        }
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            onstay = true;
        }
        
        if (other.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            onstay = false;
            other.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }
}