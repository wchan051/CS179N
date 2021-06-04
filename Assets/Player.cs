using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	// public int fiveSlimeQuest = 0;
	// public int mesopQuest = 0;
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
	int damage;
	public float vExpMod = 1.3f;
	private int hpregencounter;
	

	//text overlay
	public GameObject levelText;
	public GameObject xpText;
	public GameObject questTracker;
	public GameObject passiveTracker;
	public GameObject finalboss;
	private string activeQuest;

	//quest
	static public int questcounter; 
	static public int mesop;

	//misc
	private bool iframe;
	Animator m_Anim;
	public Animator enemy; 
	// Start is called before the first frame update
	void Start()
    {
		transform.position = new Vector3(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"), 0);

		healthBar.SetMaxHealth(maxHealth);
		xpBar.SetMaxXp(maxXp);
		if(SceneManager.GetActiveScene().name == "tutorial") {
			currentHealth = maxHealth;
			level = 1;
        	currentXp = 0;
			totalXp = 0;
			damage = 10;
			mesop = 0;
		}
		else {
			currentHealth = PlayerPrefs.GetInt("p_currentHealth");
			level = PlayerPrefs.GetInt("p_level");
        	currentXp = PlayerPrefs.GetInt("p_currentXp");
			totalXp = PlayerPrefs.GetInt("p_totalXp");
			damage = PlayerPrefs.GetInt("p_damage");
			mesop = PlayerPrefs.GetInt("p_mesop");
		}
		if (SceneManager.GetActiveScene().name == "tutorial") {
			activeQuest = "kill";
		}
		else if (SceneManager.GetActiveScene().name == "map1") {
			activeQuest = "collect";
		}
		else if (SceneManager.GetActiveScene().name == "map2") {
			activeQuest = "bossfight";
		}
		hpregencounter = 0;
		iframe = false;
		m_Anim = GetComponent<Animator>();
		questcounter = 0;
		levelText.GetComponent<Text>().text = "Lvl. " +  level;
		xpText.GetComponent<Text>().text = currentXp +  "	/	 "  + maxXp;
		if (activeQuest == "kill")
			questTracker.GetComponent<Text>().text = "Kill the slimes -		" + questcounter +   "	/	 5" ;
		else if (activeQuest == "collect")
			passiveTracker.GetComponent<Text>().text = "Collect Mesop - " + mesop + "  /  	1000";
		else if (activeQuest == "bossfight")
			finalboss.GetComponent<Text>().text = "SURVIVE or kill the boss";
	}

    // Update is called once per frame
    void Update()
    {	
		PlayerPrefs.SetInt("p_currentHealth",currentHealth);
		PlayerPrefs.SetInt("p_level",level);
		PlayerPrefs.SetInt("p_currentXp",currentXp);
		PlayerPrefs.SetInt("p_totalXp",totalXp);
		PlayerPrefs.SetInt("p_maxXp",maxXp);
		PlayerPrefs.SetInt("p_damage",damage);
		PlayerPrefs.SetInt("p_mesop", mesop);
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

		if (Input.GetKeyDown(KeyCode.Q))
		{
			pickuppassive(100);
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

		if (questcounter >= 5 && activeQuest == "kill") {
			GainXp(50);
			questcounter = 0;
			Invoke("QuestComplete", 2);
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerPrefs.SetInt("done1", 0);
			PlayerPrefs.SetInt("done2", 0);
			PlayerPrefs.SetInt("done3", 0);
			PlayerPrefs.SetInt("done4", 0);
			PlayerPrefs.SetInt("questFinished", 0);
			PlayerPrefs.SetFloat("xPosition", 0);
			PlayerPrefs.SetFloat("yPosition", 0);
			//PlayerPrefs.SetInt("done4", 0);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "slime") {
            if (iframe) {
                TakeDamage(5);
                iframe = false;
            }
        }
		else if (collision.gameObject.tag == "slime2") {
            if (iframe) {
				Debug.Log("hit by slime 2");
                TakeDamage(10);
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
			enemy = col.gameObject.GetComponent<Animator>();
			if(col.gameObject.GetComponent<slimeScript>().health > 0 && !enemy.GetBool("isHit")) {
				if(col.gameObject.GetComponent<slimeScript>().health - damage < 0) {
					col.gameObject.GetComponent<slimeScript>().health = 0;
				}
				else {
					col.gameObject.GetComponent<slimeScript>().health -= damage;
				}
			}
			StartCoroutine(waiter());
		}
		if (col.gameObject.tag == "slime2")
		{
			testing = true;
			enemy = col.gameObject.GetComponent<Animator>();
			if(col.gameObject.GetComponent<slime2>().health > 0 && !enemy.GetBool("isHit")) {
				if(col.gameObject.GetComponent<slime2>().health - damage < 0) {
					col.gameObject.GetComponent<slime2>().health = 0;
				}
				else {
					col.gameObject.GetComponent<slime2>().health -= damage;
				}
			}
			StartCoroutine(waiter());
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
	
	public void Heal (int heal) {
		currentHealth += heal;
		if(currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		healthBar.SetHealth(currentHealth);
	}
	public void questcounterincrementer(int counter) {
		questcounter += counter;
		if (activeQuest == "kill")	questTracker.GetComponent<Text>().text = "Kill the slimes -		" + questcounter +   " 	/	 5" ;
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
		damage += 5;
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
		//fiveSlimeQuest = 1;
		PlayerPrefs.SetInt("questFinished", 1);
		if (activeQuest == "kill")	questTracker.GetComponent<Text>().text = "Quest complete! 50 Xp has been rewarded!";
	}
	void upgradepassive() {
		if (mesop % 50 == 0) {
			//if (activeQuest == "collect") passiveTracker.GetComponent<Text>().text = "Increased atk power by 1";
			damage++;
		}
		if (mesop > 1000) {
			//mesopQuest = 1;
			PlayerPrefs.SetInt("questFinished", 2);
		}
	}
	public void pickuppassive(int pickup) {
		mesop = mesop + pickup;
		if (activeQuest == "collect")	passiveTracker.GetComponent<Text>().text = "Collect Mesop - " + mesop + "  /  	1000";
		upgradepassive();
	}
	IEnumerator waiter() {
		enemy.SetBool("isHit",true);
		yield return new WaitForSeconds(1);
		enemy.SetBool("isHit",false);
	}
}