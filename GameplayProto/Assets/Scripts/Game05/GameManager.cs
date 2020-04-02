using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] GameObject go;
    [HideInInspector]
    public int scoreInt;
    int bestScoreInt;
    [HideInInspector]
    public bool isActive = false;
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<GameManager>();
                
            }
            return instance;
        }
    }
    void Start()
    {
        //finir le playerprefabs
        bestScore.text = "BestScore: " + PlayerPrefs.GetInt("ScoreMax2").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreInt.ToString();

        if (isActive)
        {
            go.SetActive(true);
        }
        else
            go.SetActive(false);

        if (Input.GetKey(KeyCode.R))
        {
            if (PlayerPrefs.GetInt("ScoreMax2") < scoreInt)
            {
                PlayerPrefs.SetInt("ScoreMax2", scoreInt);
            }
            SceneManager.LoadScene(5);
            
        }
    }
}
