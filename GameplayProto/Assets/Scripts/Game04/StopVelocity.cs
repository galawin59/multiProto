using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class StopVelocity : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.y  >= collision.gameObject.transform.position.y)
            {
               
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
              
                if (GetComponent<Rigidbody>().velocity.x >= 0)
                {

                    collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 10 ;
                    GameOver.Instance.isActive = true;
                }
                if (GetComponent<Rigidbody>().velocity.x <= 0)
                {

                  collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 10;
                    GameOver.Instance.isActive = true;
                }
            }
            GetComponent<Rigidbody>().isKinematic = true;
            GameOver.Instance.scoreInt++;
          
        }
    }
}
