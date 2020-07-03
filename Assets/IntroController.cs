using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 60)
            gameObject.SetActive(false);
    }
    
    public void OnPointerClick()
    {
        gameObject.SetActive(false);
    }
}
