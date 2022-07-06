using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalesController : MonoBehaviour
{
    public Text _scalesNum;

    private void OnTriggerEnter(Collider other)
    {
        _scalesNum.text = other.gameObject.GetComponent<Rigidbody>().mass.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        _scalesNum.text = "0000";
    }
}
