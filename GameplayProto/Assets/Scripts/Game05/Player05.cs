using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player05 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject torus;
    void Start()
    {
        for (int i = 1; i < 50; i++)
        {

            Instantiate(torus, new Vector3(i * 10, Random.Range(0f, 6f),0f), Quaternion.Euler(Random.Range(340,350),0f,Random.Range(10,20)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().velocity = new Vector3(1f, 6f, 0f);
        }

    }
}
