using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecreaseNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    int num = 2;
    string number;
    Rigidbody2D rb;
    Vector2 velocity;
    static int score;
    SpriteRenderer spriteColor;
    int random;
    [SerializeField] Gradient color;
    [SerializeField] GameObject powerUp;
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        random = UnityEngine.Random.Range(0, 2);

        if (random == 0)
            rb.gravityScale = 1f;
        else
            rb.velocity = Vector2.zero;

    }
    void Start()
    {
        num = GenerateRubis.Instance.numberRubis;
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();

        spriteColor.color = color.Evaluate((float)num / 100);

        velocity = rb.velocity;
        number = Convert.ToString(num);
        text.text = number;
        StartCoroutine(Wait());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (num > 1)
            {
                num--;
                spriteColor.color = color.Evaluate((float)num / 100);
                score++;
                GameManager06.Instance.score.text = score.ToString();

                number = Convert.ToString(num);
                text.text = number;

            }
            else
            {
                score++;
                GameManager06.Instance.score.text = score.ToString();
                if (UnityEngine.Random.Range(0, 2) == 1)
                {
                   
                    GameObject go = Instantiate(powerUp, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            GameManager06.Instance.isActive = true;
            score = 0;
           
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collider")
        {
            rb.velocity = -velocity;
            velocity = rb.velocity;

        }
    }


}



