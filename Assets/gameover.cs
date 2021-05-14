using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public HealthBar healthbar;
    private float health;
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        health = healthbar.slider.value;
        if (health <= 0) {
            Destroy(player.gameObject);
            // gameover transition here
        }
    }
}
