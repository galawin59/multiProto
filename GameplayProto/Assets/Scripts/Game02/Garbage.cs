using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garbage : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update
    public Text text;
    public int num = 2;


    string number;

    void Start()
    {
        number = Convert.ToString(num);
        text.text = number;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);



        }
    }
}
