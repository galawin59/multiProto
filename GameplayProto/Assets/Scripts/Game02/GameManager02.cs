using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager02 : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    private static GameManager02 instance;

    [HideInInspector]
     public bool Isactive = false;

    public static GameManager02 Instance
    {
        get
        {
            if(instance ==null)
            {
                instance = FindObjectOfType<GameManager02>();
            }
            return instance;
        }
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Isactive)
        {
            gameOver.SetActive(true);
        }
        else
        {
            gameOver.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }
    }
}
