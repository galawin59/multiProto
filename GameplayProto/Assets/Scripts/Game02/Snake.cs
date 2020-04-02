using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject partsSnake;
    [SerializeField] Text text;
    [SerializeField] Text scoreText;
    [SerializeField] Text hpText;
    [SerializeField] Text bestScore;
    List<Transform> bodyParts = new List<Transform>();
    List<GameObject> parts = new List<GameObject>();
    int SizeSnake;
    bool iscollide = false;
    int hpPlayer;
    string number;
    string scoreNum;
    string gainHp;
    int score = 0;
    int hp;
    void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("BestScore02").ToString();
        hpPlayer = int.Parse(hpText.text);
        for (int i = 1; i <= hpPlayer; i++)
        {
            GameObject go = Instantiate(partsSnake, new Vector2(transform.position.x, transform.position.y - i * 0.09f), Quaternion.identity);
            parts.Add(go);
            bodyParts.Add(go.transform);
        }
    }

    IEnumerator MoveSnakeRight()
    {

        foreach (var tr in bodyParts)
        {
            yield return new WaitForSeconds(0.05f);
            tr.Translate(Vector2.right * 0.02f);
        }
    }
    IEnumerator MoveSnakeLeft()
    {

        foreach (var tr in bodyParts)
        {
            yield return new WaitForSeconds(0.05f);
            tr.Translate(Vector2.left * 0.02f);
        }
    }


    IEnumerator boom()
    {

        while (!GameManager02.Instance.Isactive)
        {

            yield return new WaitForSeconds(0.1f);

            if (hpPlayer != 0)
            {

                SizeSnake = bodyParts.Count;

                if (SizeSnake != 1)
                {
                    parts[SizeSnake - 1].SetActive(false);
                    bodyParts.RemoveAt(SizeSnake - 1);

                }

                hpPlayer--;
                score++;
                number = Convert.ToString(hpPlayer);
                scoreNum = Convert.ToString(score);

                text.text = number;
                scoreText.text = scoreNum;
            }


            if (hpPlayer <= 0)
            {
                hpPlayer = 0;
                parts[0].SetActive(false);
                bodyParts.RemoveAt(0);
                GameManager02.Instance.Isactive = true;
                if (PlayerPrefs.GetInt("BestScore02") < int.Parse(scoreText.text))
                {
                    PlayerPrefs.SetInt("BestScore02", int.Parse(scoreText.text));
                    bestScore.text = scoreText.text;
                }

            }


        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager02.Instance.Isactive)
        {

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * 0.02f);
                StartCoroutine(MoveSnakeRight());

            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector2.left * 0.02f);
                StartCoroutine(MoveSnakeLeft());

            }
            if (!iscollide)
            {


                transform.Translate(Vector2.up * 0.01f);

                foreach (var tr in bodyParts)
                {
                    tr.Translate(Vector2.up * 0.01f);
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            iscollide = true;
            StartCoroutine("boom");


        }
        if (collision.gameObject.tag == "Loot")
        {
            int tempHp = hpPlayer;
            gainHp = collision.gameObject.GetComponent<Garbage>().text.text;
            hp = Convert.ToInt32(gainHp);
            hpPlayer += hp;
            number = Convert.ToString(hpPlayer);
            text.text = number;

            for (int i = tempHp; i < hpPlayer; i++)
            {

                GameObject go = Instantiate(partsSnake, new Vector2(bodyParts[bodyParts.Count - 1].position.x, bodyParts[bodyParts.Count - 1].position.y - 0.09f), Quaternion.identity);
                parts.Add(go);
                bodyParts.Add(go.transform);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            iscollide = false;
            StopCoroutine("boom");
            if (hpPlayer != 0)
            {

                hpPlayer--;
                score++;
                number = Convert.ToString(hpPlayer);
                scoreNum = Convert.ToString(score);

                text.text = number;
                scoreText.text = scoreNum;
                SizeSnake = bodyParts.Count;

                if (SizeSnake != 1)
                {
                    parts[SizeSnake - 1].SetActive(false);
                    bodyParts.RemoveAt(SizeSnake - 1);


                }
            }
            if (hpPlayer <= 0)
            {
                hpPlayer = 0;
                parts[0].SetActive(false);
                bodyParts.RemoveAt(0);
                GameManager02.Instance.Isactive = true;
                if (PlayerPrefs.GetInt("BestScore02") < int.Parse(scoreText.text))
                {
                    PlayerPrefs.SetInt("BestScore02", int.Parse(scoreText.text));
                    bestScore.text = scoreText.text;
                }

            }



        }
    }
}
