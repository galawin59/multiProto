using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


//Script non utiliser ancien code 
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField] Text text;
    [SerializeField] Text scoreText;
    [SerializeField] Text bestScoreText;
    [SerializeField] int num = 2;
    [SerializeField] GameObject gameOver = null;
    [SerializeField] GameObject partPlayer = null;
    SpriteRenderer[] SizeSnake;
    int move = 0;
    bool isStart = false;
    bool isCollide = false;



    string number;
    string scoreNum;
    string gainHp;
    string bestScore;
    static int bestScoreInt;
    int hp;
    int score = 0;
    bool isOver = false;

    public bool IsOver { get => isOver; }

    IEnumerator boom()
    {

        while (true)
        {

            yield return new WaitForSeconds(0.1f);

            if (num != 0)
            {

                SizeSnake = transform.GetComponentsInChildren<SpriteRenderer>();

                if (SizeSnake.Length != 1)
                    Destroy(SizeSnake[SizeSnake.Length - 1]);

                num--;
                score++;
                number = Convert.ToString(num);
                scoreNum = Convert.ToString(score);

                text.text = number;
                scoreText.text = scoreNum;
            }


            if (num <= 0)
            {
                num = 0;
                isOver = true;
            }


        }


    }

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        number = Convert.ToString(num);
        text.text = number;
        bestScoreInt = PlayerPrefs.GetInt("BestScore");
        bestScore = Convert.ToString(bestScoreInt);
        bestScoreText.text = bestScore;

        for (int i = 1; i < num; i++)
        {

            GameObject go = Instantiate(partPlayer, new Vector3(transform.position.x, transform.position.y - (0.08f * i), transform.position.z), Quaternion.identity, transform) as GameObject;
            go.transform.SetParent(transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }


   


}
