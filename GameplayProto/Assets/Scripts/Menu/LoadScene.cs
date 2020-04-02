using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
   public void OnClickPlayGame(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    private void Awake()
    {
    
        DontDestroyOnLoad(gameObject);

       
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}


