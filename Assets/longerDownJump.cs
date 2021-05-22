using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class longerDownJump : MonoBehaviour
{
    public bool downJumping;
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
            downJumping = true;


            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine("downJumpp");


            }
        }
    }

    IEnumerator downJumpp()
    {
        downJumping = true;
        platform.GetComponent<TilemapCollider2D>().usedByEffector = false;
        Physics2D.IgnoreLayerCollision(3, 2, true);
        yield return new WaitForSeconds(1.3f);
        platform.GetComponent<TilemapCollider2D>().usedByEffector = true;
        Physics2D.IgnoreLayerCollision(3, 2, false);
        downJumping = false;
    }

    void OnTriggerExit2d(Collider2D other)
    {
        if (other.tag == "Player")
        {


            platform.GetComponent<TilemapCollider2D>().enabled = true;

        }
    }
}
