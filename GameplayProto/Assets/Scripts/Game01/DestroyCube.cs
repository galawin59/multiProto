﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.localPosition.y < 5.0f)
        {
           
            Destroy(gameObject, 1.0f);
          
        }
    }
}
