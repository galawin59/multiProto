using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlocInGame : MonoBehaviour
{
    // Start is called before the first frame update
    int idScene;
    void Start()
    {
        idScene = SceneManager.GetActiveScene().buildIndex;
       
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        if (rb.Length == 0)
        {
            
            if (idScene == 1)
                SceneManager.LoadScene(9);
            else
                SceneManager.LoadScene(idScene+1);


        }
    }
}
