using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame06 : MonoBehaviour
{
    // Start is called before the first frame update
 
    [SerializeField]float speed = 0.01f;
  
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) &&transform.position.x <  1.80f && !GameManager06.Instance.isActive)
        {

            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.Q) && transform.position.x > -1.82f && !GameManager06.Instance.isActive)
        {
            transform.Translate(Vector2.left * speed);
       
        }
        
        


    }



}
