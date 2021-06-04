using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprojectilememe : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    Player player;
    GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        slime = GameObject.FindGameObjectWithTag("boss").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.name != "playerweapon") {
            if (player.transform.position.x <= slime.transform.position.x) {
                rb2d.velocity = new Vector2(12,0);
            }
            else {
                rb2d.velocity = new Vector2(-12, 0);
            }
        } 
        if ((transform.position.x < -21 || transform.position.x > 76) && this.gameObject.name == "playerweapon(Clone)") destroyproj();
    }

    // private void OnTriggerEnter2D(Collider2D collider) {
    //     destroyproj();
    //     player.Heal(-10);
    // }

    private void OnCollisionEnter2D(Collision2D collision) {
        //if (collision.gameObject.tag == "boss") {
        //     player.Heal(-10);
            destroyproj();
        //}
        if (collision.gameObject.tag == "boss") {
            // TODO: REDUCE SLIME HEALTH
        }
    }

    private void destroyproj() {
        Destroy(gameObject);
    }
}
