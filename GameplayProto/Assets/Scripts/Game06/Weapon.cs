using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firepoint;
    // Start is called before the first frame update

    private static Weapon instance;
    public static Weapon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Weapon>();
            }
            return instance;
        }
    }
    // Update is called once per frame
    int count;
    [HideInInspector]
    public int speedFire = 1;
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        count = 0;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && count <= speedFire && !GameManager06.Instance.isActive )
        {
            count++;
            if (count <= 1)
            {
                GameObject go = Instantiate(bullet, new Vector2(firepoint.position.x, firepoint.position.y), Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = Vector3.up * 12f;
                Destroy(go, 2f);

            }
            else
            {
                StartCoroutine(Wait());
            }
        }

    }

}

