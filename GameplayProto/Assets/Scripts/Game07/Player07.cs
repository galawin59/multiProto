using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player07 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 0.01f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && !GameManager07.Instance.isActive)
        {

            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.Q) && !GameManager07.Instance.isActive)
        {
            transform.Translate(Vector2.left * speed);

        }

    }

  
}
