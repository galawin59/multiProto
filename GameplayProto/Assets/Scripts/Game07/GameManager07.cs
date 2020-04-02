using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager07 : MonoBehaviour
{
    public TextMeshProUGUI score;

    [HideInInspector]
    public bool isActive = false;
    [HideInInspector]
    public bool powerUpIsActive = false;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scoreInGame;
    [SerializeField] GameObject scoreHud;
    [SerializeField] GameObject besScoreHud;
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        Weapon07.Instance.speedFire = 1;
        powerUpIsActive = false;
    }

    private static GameManager07 instance;

    public static GameManager07 Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<GameManager07>();
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
            if(PlayerPrefs.GetInt("BestScore07") < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("BestScore07", int.Parse(score.text));

            }
            besScoreHud.GetComponent<TextMeshProUGUI>().text = "Best : " + PlayerPrefs.GetInt("BestScore07").ToString();
            gameOver.SetActive(true);
            scoreInGame.SetActive(false);
            scoreHud.SetActive(true);
            besScoreHud.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            gameOver.SetActive(false);
            scoreInGame.SetActive(true);
            scoreHud.SetActive(false);
            besScoreHud.SetActive(false);
        }

        if (Input.GetKey(KeyCode.R) && isActive)
        {
            SceneManager.LoadScene(7);
        }

        if(powerUpIsActive)
        {
            StartCoroutine(Wait());
        }
    }
}
