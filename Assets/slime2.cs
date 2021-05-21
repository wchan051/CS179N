using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime2 : MonoBehaviour
{
    public Animator ani; 
    private GameObject enemy, enemyclone;
    public int health = 100;
    private bool iframe, deadquestionmark;
    private int fpscounter;
    Player user;
    Vector3 respawnposition;
    // public int player-experience;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        health = 100;
        fpscounter = 0;
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = gameObject.transform.gameObject;
        enemyclone = gameObject.transform.gameObject;
        respawnposition = new Vector3(11,-4,0);
        deadquestionmark = false;
    }

    // Update is called once per frame
    void Update()
    {
        fpscounter++;

        if (health <= 0)
        {
            StartCoroutine(waiter());

        }
    }

    IEnumerator waiter() {
        if(health <= 0 && !deadquestionmark) {
            deadquestionmark = true;
            ani.SetBool("isDead", true);
            user.GainXp(11);
            user.questcounterincrementer(1);
            yield return new WaitForSeconds(2);
            enemy.gameObject.SetActive(false);
            Invoke("respawn", 5);
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
