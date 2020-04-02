using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> torus = null;
    [SerializeField] Transform sphere = null;
    Transform[] listTransforms = null;
    int size = 10;
    int random = 0;
    void Start()
    {

        for (int i = 0; i < torus.Count - 1; i++)
        {
            for (int j = 0; j < size; j++)
            {
                 random = Random.Range(1, 5);
               
                if (random == 1 )
                {

                }
                else
                {
                    GameObject go = Instantiate(torus[i], new Vector3(torus[i].transform.position.x, torus[i].transform.position.y - (j * 5), torus[i].transform.position.z), torus[i].transform.rotation) as GameObject;

                    go.transform.parent = transform;

                }
            }
        }


        //listTransforms = transform.GetComponentsInChildren<Transform>();
      //  Debug.Log("transform = " + listTransforms.Length);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
