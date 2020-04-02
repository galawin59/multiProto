using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hit07 : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI hpSquareText;
    [SerializeField] Gradient color;
    SpriteRenderer spriteColor;

    int hpSquareInt;
    static  int numScore;
    void Start()
    {
      
        spriteColor = GetComponent<SpriteRenderer>();
        hpSquareInt = int.Parse(hpSquareText.text);
        spriteColor.color = color.Evaluate((float)hpSquareInt / 100);
    }


    void Update()
    {
        if(GameManager07.Instance.isActive)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (hpSquareInt > 0)
            {
                numScore++;
                GameManager07.Instance.score.text = numScore.ToString();
                hpSquareInt--;
                hpSquareText.text = hpSquareInt.ToString();
            }
            if (hpSquareInt <= 0)
            {
               
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            numScore = 0;
            GameManager07.Instance.isActive = true;
        }
    }
}
