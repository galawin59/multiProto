using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGame04 : MonoBehaviour
{
    Rigidbody rb;
    bool isAir = false;
   
   
    // Start is called before the first frame update
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -100f, 0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAir)
        {
            rb.velocity = Vector3.up * 22;
        }
        if (Input.GetKey(KeyCode.R))
        {
        
            if (PlayerPrefs.GetInt("ScoreMax") < GameOver.Instance.scoreInt)
            {
               
                PlayerPrefs.SetInt("ScoreMax", GameOver.Instance.scoreInt);
             
              
            }
            SceneManager.LoadScene(4);


        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        isAir = false;
      
    }
    private void OnCollisionExit(Collision collision)
    {
        isAir = true;
    }
}
