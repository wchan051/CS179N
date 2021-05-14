using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ladder : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;
    float distance;
    LayerMask Ladder;
    bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, Ladder);
        if (hitInfo.collider != null)
        {   
            Debug.Log(hitInfo.collider.name);
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                isClimbing = true;
            }
            else {
                isClimbing = false;
            }
        }

        if (isClimbing) {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical*speed);
            rb.gravityScale = 0;
        }
        else {
            rb.gravityScale = 5;
        }
    }
}