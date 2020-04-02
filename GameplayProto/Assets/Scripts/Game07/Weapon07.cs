using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon07 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firepoint;
    // Start is called before the first frame update

    private static Weapon07 instance;
    public static Weapon07 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Weapon07>();
            }
            return instance;
        }
    }
    int count;
    [HideInInspector]
    public int speedFire = 1;

    // Update is called once per frame
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        count = 0;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && count <= speedFire && !GameManager07.Instance.isActive)
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
