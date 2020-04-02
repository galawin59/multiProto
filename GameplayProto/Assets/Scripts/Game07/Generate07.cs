using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate07 : MonoBehaviour
{

    [SerializeField] Transform spawn;
    [SerializeField] GameObject square;
    [SerializeField] GameObject powerUp;
    [SerializeField] Transform spawnPowerUp;
    [SerializeField] Hit07 hit;

    int hpSquareint;
    int count;
    IEnumerator Wait()
    {
        while (!GameManager07.Instance.isActive)
        {
            yield return new WaitForSeconds(2f);
            count++;
            for (int i = 0; i < 4; ++i)
            {

                GameObject go = Instantiate(square, new Vector2(spawn.position.x + (i * 2f), spawn.position.y), Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5f;
                hpSquareint = Random.Range(1, 4 + count);
                hit.hpSquareText.text = hpSquareint.ToString();
                Destroy(go, 6f);

            }
            //modifier le power up pour plus de random et faire en sorte davoir plus de puisssance!!!
            if(count % 2 == 0)
            {
                GameObject go = Instantiate(powerUp, new Vector2(spawnPowerUp.position.x + Random.Range(0f,6f), spawnPowerUp.position.y), Quaternion.identity);
            }
        }
    }
    void Start()
    {

        StartCoroutine(Wait());
    }


    void Update()
    {

    }
}
