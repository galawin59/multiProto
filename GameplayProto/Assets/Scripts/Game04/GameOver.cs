using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject go;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI bestScore;
    [HideInInspector]
    public bool isActive = false;
    [HideInInspector]
    public int scoreInt;

    private static GameOver instance;

    public static GameOver Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameOver>();
            }
            return instance;
        }
        
    }
    void Start()
    {
        bestScore.text = "BestScore :" + PlayerPrefs.GetInt("ScoreMax");
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            go.SetActive(true);
        }
        else
            go.SetActive(false);

        score.text = scoreInt.ToString();
        bestScore.text = "BestScore : " + PlayerPrefs.GetInt("ScoreMax");
    }
}
