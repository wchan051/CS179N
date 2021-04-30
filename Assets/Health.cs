using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	private int hpregencounter;
	private bool iframe;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
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
}
