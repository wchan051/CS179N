using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public HealthBar healthBar;
	public XpBar xpBar;
	public bool testing = false;
	//data for exp,health,xp
	static public int totalXp;
    static public int maxHealth = 100;
	static public int currentHealth;
	static public int maxXp = 10;
	static public int currentXp;
    static public int level;
	int damage = 10;
	public float vExpMod = 1.3f;
	private int hpregencounter;

	//text overlay
	public GameObject levelText;
	public GameObject xpText;
	public GameObject questTracker;

	//quest
	static public int questcounter; 

	//misc
	private bool iframe;
	Animator m_Anim;
	public Animator enemy; 
	// Start is called before the first frame update
	void Start()
    {
		healthBar.SetMaxHealth(maxHealth);
		xpBar.SetMaxXp(maxXp);
		if(SceneManager.GetActiveScene().name == "tutorial") {
			currentHealth = maxHealth;
			level = 1;
        	currentXp = 0;
			totalXp = 0;
		}
		else {
			currentHealth = PlayerPrefs.GetInt("p_currentHealth");
			level = PlayerPrefs.GetInt("p_level");
        	currentXp = PlayerPrefs.GetInt("p_currentXp");
			totalXp = PlayerPrefs.GetInt("p_totalXp");
		
		}
		hpregencounter = 0;
		iframe = false;
		m_Anim = GetComponent<Animator>();
		questcounter = 0;
		levelText.GetComponent<Text>().text = "Lvl. " +  level;
		xpText.GetComponent<Text>().text = currentXp +  "	/	 "  + maxXp;
		questTracker.GetComponent<Text>().text = "Kill the slimes -		" + questcounter +   "	/	 5" ;
	}

    // Update is called once per frame
    void Update()
    {	
		PlayerPrefs.SetInt("p_currentHealth",currentHealth);
		PlayerPrefs.SetInt("p_level",level);
		PlayerPrefs.SetInt("p_currentXp",currentXp);
		PlayerPrefs.SetInt("p_totalXp",totalXp);
		PlayerPrefs.SetInt("p_maxXp",maxXp);

		xpText.GetComponent<Text>().text = currentXp +  "	/	 "  + maxXp;
		xpBar.SetXp(currentXp);
		//Used for debugging(take 10 damage)
		if (Input.GetKeyDown(KeyCode.Z))
		{
			TakeDamage(10);
		}

		//Replace with health potions
		if (Input.GetKeyDown(KeyCode.C))
		{
			Heal(20);
		}

		//Used for debugging(gain 10 xp)
		if(Input.GetKeyDown(KeyCode.X)) {
            GainXp(10);
        }

		if(Input.GetKeyDown(KeyCode.Q)) { 
            GetComponent<Animator>().Play("stab");
        }

		if (!iframe && currentHealth < maxHealth) {
			iframe = true;
			currentHealth++; // alter for future use
			//Debug.Log("hpregen");
			healthBar.SetHealth(currentHealth);
		}
		hpregencounter++;
		if (hpregencounter > 1500) {
			iframe = false;
			hpregencounter = 0;
		}

		if (questcounter >= 5) {
			GainXp(50);
			questcounter = 0;
			Invoke("QuestComplete", 2);
		}
    }
	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "slime") {
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

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "slime")
		{
			testing = true;
			col.gameObject.GetComponent<slimeScript>().health -= damage;
			enemy = col.gameObject.GetComponent<Animator>();
			StartCoroutine(waiter());
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
	
	void Heal (int heal) {
		currentHealth += heal;
		if(currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		healthBar.SetHealth(currentHealth);
	}
	public void questcounterincrementer(int counter) {
		questcounter += counter;
		questTracker.GetComponent<Text>().text = "Kill the slimes -		" + questcounter +   " 	/	 5" ;
	}

	void LevelUp(int exp) {
        level++;
		levelText.GetComponent<Text>().text = "Lvl. " +  level;
		float t = Mathf.Pow(vExpMod, level);
        maxXp = (int)Mathf.Floor(10 * t) + 25;
        xpBar.SetMaxXp(maxXp);
		currentXp = exp;
		xpBar.SetXp(currentXp);
		maxHealth += 25;
		healthBar.SetMaxHealth(maxHealth);
		currentHealth = maxHealth;
        //TO-DO: Add level up animation
    }

	public void GainXp(int xpGain)
	{
		int carryXp;

		currentXp += xpGain;
		totalXp += xpGain;
		
    	while (currentXp >= maxXp) {
			carryXp = currentXp - maxXp;
			LevelUp(carryXp); 	
        }

		xpBar.SetXp(currentXp);
	}
	
	void QuestComplete () {
		questTracker.GetComponent<Text>().text = "Quest complete! 50 Xp has been rewarded!";
	}
	IEnumerator waiter() {
		enemy.SetBool("isHit",true);
		yield return new WaitForSeconds(1);
		enemy.SetBool("isHit",false);
	}
	
}