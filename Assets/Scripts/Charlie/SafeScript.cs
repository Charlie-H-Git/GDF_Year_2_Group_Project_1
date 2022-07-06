using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeScript : MonoBehaviour
{
    //public GameObject[] Keys;

    public GameObject Keypad;


    public PickUp pickUp; // this reference is for your camera 

    private void Update()
    {
        StartCoroutine(BoolCheck());
    }

    IEnumerator BoolCheck()
    {
        if (pickUp.keypad)
        {
            
            Keypad.SetActive(true);
        }
        else if (pickUp.keypad == false)
        {
            Keypad.SetActive(false);
        }

        yield return new WaitForSeconds(0.1f);
    }
}
