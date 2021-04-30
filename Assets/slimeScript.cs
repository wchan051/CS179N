using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public Animator ani; 
    private GameObject enemy;
    private int slimecurrenthealth = 100;
    private bool iframe;
    private int fpscounter;
    // public int player-experience;
    // Start is called before the first frame update
    void Start()
    {
        slimecurrenthealth = 100;
        fpscounter = 0;
        iframe = true;
        enemy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //move slime
        // // assuming game is running at 60 fps
        // if (iframe) {
        //     // if collision happens with player
        //     OnTriggerEnter(slimecollider);
        // }
        // // insert ai for slime moving to player
        // fpscounter++;
        // if (fpscounter > 120) {
        //     fpscounter = 0;
        //     iframe = true;
        // }
        // // if (slimecurrenthealth <= 0) {
        // //     this.transform.localScale = new Vector3 (0,0,0);
        // // }
        if (slimecurrenthealth <= 0) {
            Destroy(enemy.gameObject);
            // experience here
        }
        fpscounter++;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "CharacterRobotBoy") {
            if (iframe) {
                slimecurrenthealth -= 10;
                iframe = false;
                Debug.Log("health reduced");
            }
        } 
        if (fpscounter > 900) {
            fpscounter = 0;
            iframe = true;   
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        //if collider = player
        //then reduce player's life
        Debug.Log("ontriggerenter");
        if (other == playercollider) {
            slimecurrenthealth -= 10;
            iframe = false;
            Debug.Log("health reduced");
        }
    }*/
}
