using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager06 : MonoBehaviour
{
    public TextMeshProUGUI score;

    [HideInInspector]
    public bool powerUpIsActive = false;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scoreInGame;
    [SerializeField] GameObject scoreHud;
    [SerializeField] GameObject besScoreHud;

    [HideInInspector]
    public bool isActive = false;


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        Weapon.Instance.speedFire = 1;
        powerUpIsActive = false;
    }
    private static GameManager06 instance;
    public static GameManager06 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager06>();
            }

            return instance;
        }
    }




    void Update()
    {
        score.text = score.text;
        if (isActive)
        {
            scoreHud.GetComponent<TextMeshProUGUI>().text = "Score : " + score.text;
            if (PlayerPrefs.GetInt("BestScore06") < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("BestScore06", int.Parse(score.text));

            }
            besScoreHud.GetComponent<TextMeshProUGUI>().text = "Best : " + PlayerPrefs.GetInt("BestScore06").ToString();
            gameOver.SetActive(true);
            scoreInGame.SetActive(false);
            scoreHud.SetActive(true);
            besScoreHud.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            
            gameOver.SetActive(false);
            scoreInGame.SetActive(true);
            scoreHud.SetActive(false);
            besScoreHud.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.R) && isActive)
        {
            SceneManager.LoadScene(6);
        }

        if (powerUpIsActive)
        {
            StartCoroutine(Wait());
        }
    }
}

