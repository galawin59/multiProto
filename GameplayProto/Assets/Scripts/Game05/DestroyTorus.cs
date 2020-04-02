using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTorus : MonoBehaviour
{
    [SerializeField] Canvas gameOver;
    Player05 player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player05>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x + 3f < player.transform.position.x )
        {
          
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.Instance.isActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(transform.parent.gameObject);
            GameManager.Instance.scoreInt++;
        }
    }
}
