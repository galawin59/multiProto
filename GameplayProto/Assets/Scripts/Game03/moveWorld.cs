﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down);
        }
    }
}
