﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - .2f, gameObject.transform.position.y);
    }
}
