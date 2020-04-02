using System.Collections;
using UnityEngine;

public class GenerateRubis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] spawn;
    [SerializeField] GameObject rubis;
    [SerializeField] float speed = 0.1f;
    public int numberRubis;
    int randomSpawn;
    int count = 1;

    private static GenerateRubis instance;

    public static GenerateRubis Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GenerateRubis>();
            }

            return instance;
        }
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    IEnumerator Generate()
    {
        while (!GameManager06.Instance.isActive)
        {

            yield return new WaitForSeconds(2f);
            randomSpawn = Random.Range(0, 2);
            count++;
            GameObject go = Instantiate(rubis, spawn[randomSpawn].position, Quaternion.identity);
            numberRubis = Random.Range(1, count+2);
            if (randomSpawn == 0)
            {
                go.GetComponent<Rigidbody2D>().velocity = Vector2.right;
            }
            else
            {
                go.GetComponent<Rigidbody2D>().velocity = Vector2.left;

            }

        }
    }


    void Start()
    {
        StartCoroutine(Generate());
    }


}
