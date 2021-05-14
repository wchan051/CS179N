using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public Animator ani; 
    private GameObject enemy, enemyclone;
    private int slimecurrenthealth = 50;
    private bool iframe, deadquestionmark;
    private int fpscounter, attackReset;
    Player user;
    Vector3 respawnposition;
    // public int player-experience;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        slimecurrenthealth = 50;
        fpscounter = 0;
        attackReset = 0;
        iframe = true;
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = gameObject.transform.gameObject;
        enemyclone = gameObject.transform.gameObject;
        respawnposition = new Vector3(11,-4,0);
        deadquestionmark = false;
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
        StartCoroutine(waiter());
        if(ani.GetBool("isHit") == true) {
            attackReset++;
        }
        if (ani.GetBool("isHit") == true && attackReset > 120) {
            attackReset = 0;
            ani.SetBool("isHit", false);
        }
        fpscounter++;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "CharacterRobotBoy") {
            if (iframe && slimecurrenthealth > 0) {
                ani.SetBool("isHit", true);
                slimecurrenthealth -= 10;
                Debug.Log(slimecurrenthealth);
                iframe = false;
                Debug.Log("health reduced");

            }
        } 
        if (fpscounter > 300) {
            fpscounter = 0;
            iframe = true;   
        }
    }

    IEnumerator waiter() {
        Debug.Log("waiting");
        if(slimecurrenthealth <= 0 && !deadquestionmark) {
            deadquestionmark = true;
            Debug.Log("dead");
            ani.SetBool("isDead", true);
            user.GainXp(110);
            yield return new WaitForSeconds(3);
            enemy.gameObject.SetActive(false);
            Invoke("respawn", 5);
            // GameObject enemyrespawn = (GameObject)Instantiate(enemyclone);
            // enemyrespawn.transform.position = respawnposition;
            // Destroy(enemy.gameObject);
            // user.GainXp(110);
        }   
    }

    void respawn() {
        GameObject enemyrespawn = (GameObject)Instantiate(enemyclone);
        enemyrespawn.transform.position = respawnposition;
        Destroy(enemy.gameObject);
        enemyrespawn.SetActive(true);
        user.questcounterincrementer(1);
        deadquestionmark = false;
        // user.GainXp(110);
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
