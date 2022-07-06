using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [Header("Player Interaction Settings")]
    public Transform hands;
    public float interactionDistance = 5f;
    public float moveForce = 25;
    public float objectDrag = 100;
    public GameObject heldObj;
    private Vector3 neutral = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    
    public bool keypad;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void RaycastDebug()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, interactionDistance) )
        {
            if (hit.transform.gameObject.CompareTag("Interactable"))
            {
                Debug.Log("Interactable Object Hit"); 
            }
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //RaycastDebug();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, interactionDistance))
                {
                    if (hit.collider.CompareTag("KeyPad"))
                    {
                        keypad = true;
                    }
                    if (hit.transform.gameObject.CompareTag("Interactable"))
                    {
                        //Debug.Log(hit.transform.gameObject.name);
                        //Debug.Log("Interactable Object Hit"); 
                    }
                    
                    
                    GrabController(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
        }
       
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * interactionDistance);
        //hands.transform.position = _camera.transform.position + (_camera.transform.forward * interactionDistance);
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position,hands.position) > 0.1f)
        {
            Vector3 moveDirection = hands.position - heldObj.transform.position;
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }
    void GrabController(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.CompareTag("Interactable"))
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = objectDrag;
            objRig.transform.parent = hands;
            heldObj = pickObj;
            if (pickObj.name == "Panel")
            {
                pickObj.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.velocity = neutral;
        heldRig.angularVelocity = neutral;
        heldRig.useGravity = true;
        heldRig.drag = 0.5f;
        
        heldObj.transform.parent = null;
        heldObj = null;
    }
}
