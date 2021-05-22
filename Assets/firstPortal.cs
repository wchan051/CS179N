using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPortal : MonoBehaviour
{
    public bool touched = false;
    public bool spacedown = false;
    public bool questDone = false;
    void OnTriggerStay2D(Collider2D other)
    {
        //touched = true;

        if (other.gameObject.tag == "Player" && spacedown && questDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            touched = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        questDone = GameObject.Find("CharacterRobotBoy").GetComponent<Player>().fiveSlimeQuest;
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
