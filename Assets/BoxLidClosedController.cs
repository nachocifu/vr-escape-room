﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLidClosedController : MonoBehaviour
{
    
    public GameObject OtherGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(OtherGameObject.activeSelf);
    }
}
