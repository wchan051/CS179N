using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class downJump : MonoBehaviour
{
    public bool onCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnColliderStay(Collider other)
    {
        onCollider = true;
        if (other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }

}
