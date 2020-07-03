using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour
{
    public GameObject combination1;
    public GameObject combination2;
    public GameObject combination3;

    public GameObject baultDoor;
    public GameObject baultFloor;
    
    

    // Update is called once per frame
    void Update()
    {
        PadCombinationDigitController num1 = combination1.GetComponent<PadCombinationDigitController>();
        PadCombinationDigitController num2 = combination2.GetComponent<PadCombinationDigitController>();
        PadCombinationDigitController num3 = combination3.GetComponent<PadCombinationDigitController>();

        if (num1.isOk && num2.isOk && num3.isOk)
        {
            baultDoor.SetActive(false); // open bault
            baultFloor.SetActive(true); //enable standing on front of bault
            gameObject.SetActive(false); // close numpad
        }
        
    }
}
