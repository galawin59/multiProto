using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp06 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            GameManager06.Instance.powerUpIsActive = true;
            Weapon.Instance.speedFire = 5;

        }
    }
}
