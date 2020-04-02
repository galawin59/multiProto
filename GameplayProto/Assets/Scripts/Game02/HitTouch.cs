using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public int num = 2;
    string number;

    IEnumerator boom()
    {
        while (num != 0)
        {
            
            yield return new WaitForSeconds(0.1f);

            
            num--;
            number = Convert.ToString(num);

            text.text = number;
        }
        
        Destroy(gameObject);
    }
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
            StartCoroutine("boom");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StopCoroutine("boom");
        }
    }


}
