using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pickedUpSword : MonoBehaviour
{
    public bool pickedUp = false;
    public GameObject swordd;
    Animator anim;
    //gameObject Sword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            pickedUp = true;
            anim = other.GetComponent<Animator>();
            anim.SetBool("sword", true);
            anim.SetInteger("damage", anim.GetInteger("damage") +50);

            swordd.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
