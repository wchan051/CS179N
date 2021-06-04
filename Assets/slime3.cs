using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime3 : MonoBehaviour
{
    public Animator ani; 
    private GameObject enemy, enemyclone;
    public int health = 1000;
    private bool iframe, deadquestionmark;
    private int fpscounter;
    Player user;
    Vector3 respawnposition;
    public GameObject projectile;
    // public int player-experience;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        health = 1000;
        fpscounter = 0;
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = gameObject.transform.gameObject;
        enemyclone = gameObject.transform.gameObject;
        respawnposition = this.transform.position;
        deadquestionmark = false;
        projectile = GameObject.FindGameObjectWithTag("projectile").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        fpscounter++;

        if (health <= 0)
        {
            StartCoroutine(waiter());
        }

        if (fpscounter%1000 == 0) {
            SpriteRenderer flip = projectile.GetComponent<SpriteRenderer>();
            if (user.transform.position.x <= enemy.transform.position.x) flip.flipX = false;
            else flip.flipX = true;
            GameObject proj = (GameObject)Instantiate(projectile);
            proj.transform.position = new Vector3(transform.position.x - .4f, transform.position.y + .2f, -1); //FIXME
        }

        if (fpscounter % 100 == 0 && ani.GetBool("isHit")) {
            ani.SetBool("isHit", false);
        }
    }

    IEnumerator waiter() {
        if(health <= 0 && !deadquestionmark) {
            deadquestionmark = true;
            ani.SetBool("isDead", true);
            user.GainXp(1337);
            user.questcounterincrementer(1);
            yield return new WaitForSeconds(2);
            enemy.gameObject.SetActive(false);
            Invoke("respawn", 100);
        }   
    }

    private void OncollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Fire") {
            ani.SetBool("isHit", true);
            if (health - 100 < 0) {
                health = 0;
            }
            else {
                health = health - 100;
            }
        }
    }
    public void projhit(int basedamage) {
        if (health - basedamage < 0) {
            health = 0;
        }
        else {
            health = health - basedamage;
        }
    }
    void respawn() {
        GameObject enemyrespawn = (GameObject)Instantiate(enemyclone);
        enemyrespawn.transform.position = respawnposition;
        Destroy(enemy.gameObject);
        enemyrespawn.SetActive(true);
        deadquestionmark = false;
    }
}
