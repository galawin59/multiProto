﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,0f,0f);
    }


}
