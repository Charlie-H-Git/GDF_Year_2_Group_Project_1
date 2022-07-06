using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Fusebox : MonoBehaviour
{
    private PickUp _pickUp;
    public List<GameObject> Slots;
    public GameObject Light;
    public bool[] FuseArray = new bool[] { false, false, false, false };
    private bool Done;

    public bool GetBool()
    {
        return Done;
    }
    private void Start()
    {
        _pickUp = FindObjectOfType<PickUp>();
    }

    private void Update()
    {
        if (FuseArray.All(FuseArray => FuseArray))
        {
            //Debug.Log("Light On");
            Light.GetComponent<Light>().enabled = true;
            Done = true;
        }
    }

    
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Interactable") && other.gameObject.name == "Fuse 1")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.eulerAngles = Vector3.zero;
            other.transform.position = Slots[0].transform.position;
            other.transform.parent = Slots[0].transform.parent;
            FuseArray[0] = true;
            _pickUp.heldObj = null;
        }
        if (other.gameObject.CompareTag("Interactable") && other.gameObject.name == "Fuse 2")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.eulerAngles = Vector3.zero;
            other.transform.position = Slots[1].transform.position;
            other.transform.parent = Slots[1].transform.parent;
            FuseArray[1] = true;
            _pickUp.heldObj = null;
        }
        if (other.gameObject.CompareTag("Interactable") && other.gameObject.name == "Fuse 3")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.eulerAngles = Vector3.zero;
            other.transform.position = Slots[2].transform.position;
            other.transform.parent = Slots[2].transform.parent;
            FuseArray[2] = true;
            _pickUp.heldObj = null;
        }
        if (other.gameObject.CompareTag("Interactable") && other.gameObject.name == "Fuse 4")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.eulerAngles = Vector3.zero;
            other.transform.position = Slots[3].transform.position;
            other.transform.parent = Slots[3].transform.parent;
            FuseArray[3] = true;
            _pickUp.heldObj = null;
        }
    }
}
