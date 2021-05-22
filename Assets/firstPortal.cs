using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPortal : MonoBehaviour
{
    public bool touched = false;
    public bool spacedown = false;
    float xPosition = 0f;
    public int questDone = 0;
    void OnTriggerStay2D(Collider2D other)
    {
        //touched = true;

        if (other.gameObject.tag == "Player" && spacedown && questDone==1)
        {
            //xPosition = GameObject.Find("CharacterRobotBoy").transform.position.x;
            PlayerPrefs.SetFloat("tutorialxPosition", xPosition);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            touched = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        questDone= PlayerPrefs.GetInt("questFinished");
    }

    // Update is called once per frame
    void Update()
    {
        if(questDone == 0)
        {
            questDone = GameObject.Find("CharacterRobotBoy").GetComponent<Player>().fiveSlimeQuest;
        }
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            spacedown = true;
        }
        else
        {
            spacedown = false;
        }
    }
}
