using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public HealthBar healthBar;
	public XpBar xpBar;

    public int maxHealth = 100;
	public int currentHealth;

	public int maxXp = 100;
	public int currentXp;
    public int level;

	private int hpregencounter;
	private bool iframe;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		level = 1;
        currentXp = 0;
		xpBar.SetMaxXp(maxXp);
		hpregencounter = 0;
		iframe = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			TakeDamage(10);
		}

		if(Input.GetKeyDown(KeyCode.X)) { //TO-DO: Change to happen on monster kill
            GainXp(10);
        }

		if (!iframe && currentHealth < maxHealth) {
			iframe = true;
			currentHealth++; // alter for future use
			Debug.Log("hpregen");
			healthBar.SetHealth(currentHealth);
		}
		hpregencounter++;
		if (hpregencounter > 3000) {
			iframe = false;
			hpregencounter = 0;
		}
    }
	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "slime") {
            if (iframe) {
                TakeDamage(5);
                iframe = false;
            }
        } 
        if (hpregencounter > 900) {
            hpregencounter = 0;
            iframe = true;   
        }
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	void LevelUp(int exp) {
        level++;
		maxXp += 100;
        xpBar.SetMaxXp(maxXp); //TO-DO: Add parabolic experience system
		currentXp = exp;
		maxHealth += 25;
		healthBar.SetMaxHealth(maxHealth);
		currentHealth = maxHealth;
        //TO-DO: Add level up animation
    }

	public void GainXp(int xpGain)
	{
		int carryXp;
		currentXp += xpGain;
        if(currentXp >= maxXp) {
            carryXp = currentXp % maxXp;
			LevelUp(carryXp);
        }
		xpBar.SetXp(currentXp);
        
	}

}
