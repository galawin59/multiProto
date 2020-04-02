using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp07 : MonoBehaviour
{
    // Start is called before the first frame update
    bool isActive = false;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 5f;
    }

  
    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
       
            Destroy(gameObject);
            GameManager07.Instance.powerUpIsActive = true;
            Weapon07.Instance.speedFire = 5;
           
        }
    }
}
