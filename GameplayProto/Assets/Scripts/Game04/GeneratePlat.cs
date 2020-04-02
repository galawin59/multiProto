using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlat : MonoBehaviour
{

    [SerializeField] GameObject plateform;

    // Start is called before the first frame update
    bool isCollide = false;
    bool isInstanciate = false;
    float timer = 0.0f;
    int count = 0;
    GameObject go;
    int random;
    int randomSpawn;
   

    void Start()
    {

        go = Instantiate(plateform, new Vector3(10f,0f, 0f), Quaternion.identity);
        go.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;



        if (timer >= Random.Range(1.6f, 2.1f))
        {

            if (!isInstanciate && !GameOver.Instance.isActive)
            {
                random = Random.Range(5, 10);
                randomSpawn = Random.Range(1, 3);
                if (randomSpawn == 1)
                {
                    go = Instantiate(plateform, new Vector3(12f, count, 0f), Quaternion.identity);
                    go.GetComponent<Rigidbody>().velocity = Vector3.left * random;

                }
                else
                {
                    go = Instantiate(plateform, new Vector3(-12f, count, 0f), Quaternion.identity);
                    go.GetComponent<Rigidbody>().velocity = Vector3.right * random;

                }
                isInstanciate = true;

            }
            timer = 0.0f;
            isInstanciate = false;
            count++;
        }






    }

}

