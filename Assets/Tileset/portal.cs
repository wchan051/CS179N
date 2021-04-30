using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool touched = false;
    void OnCollisionEnter(Collision other)
    {
        
        /**
         if(other.tag ==player && space down ){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
         * **/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
