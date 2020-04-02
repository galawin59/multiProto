using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject square = null;
    [SerializeField] GameObject loot = null;
    string number;
    int num = 1;
    int size = 150;
    float posX01 = -0.389f;
    float posX02 = -0.241f;
    float posX03 = -0.084f;
    float posX04 = 0.074f;
    float posX05 = 0.233f;
    float[] pos;

    void Start()
    {


        pos = new float[5];
        pos[0] = posX01;
        pos[1] = posX02;
        pos[2] = posX03;
        pos[3] = posX04;
        pos[4] = posX05;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject go = Instantiate(square, new Vector3(pos[i], j), Quaternion.identity);
                Text numberText = go.GetComponentInChildren<Text>();
                HitTouch script = go.AddComponent<HitTouch>();
                script.text = numberText;
                if (j < 10)
                    script.num = UnityEngine.Random.Range((j / 5)+1, 5);
                else
                    script.num = UnityEngine.Random.Range(j / 5, j / 2);
            }
        }
        for (int i = 0; i < size; i++)
        {
            GameObject go2 = Instantiate(loot, new Vector3(pos[UnityEngine.Random.Range(1, 5)], i - 0.5f), Quaternion.identity);
            Text numberText2 = go2.GetComponentInChildren<Text>();
            Garbage script2 = go2.AddComponent<Garbage>();
            script2.text = numberText2;
            if (i < 10)
                script2.num = UnityEngine.Random.Range(1, 5);
            else
                script2.num = UnityEngine.Random.Range(i/5, i/3);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
