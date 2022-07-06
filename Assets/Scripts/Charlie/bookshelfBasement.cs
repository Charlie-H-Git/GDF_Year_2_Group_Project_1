using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class bookshelfBasement : MonoBehaviour
{
   public GameObject BookSlot;
   public Transform MoveTo;
   public bool BookIn = false;
   [Range(0,5)]public float Smoothing;
   private GameObject _BookShelf;
   public float waitTime;
   private PickUp _pickUp;
   private Fusebox _fusebox;
   
   
   private void Awake()
   {
      _BookShelf = gameObject;
      _pickUp = FindObjectOfType<PickUp>();
      _fusebox = FindObjectOfType<Fusebox>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Interactable") && other.gameObject.name == "Book")
      {
         other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
         _pickUp.heldObj = null;
         GameObject Book = other.gameObject;
         Book.transform.eulerAngles = new Vector3(0, 90, 180f);
         Book.transform.position = BookSlot.transform.position;
         Book.transform.parent = BookSlot.transform;
         BookIn = true;

      }
   }
   
   private void Update()
   {
      if (BookIn && _fusebox.GetBool())
      {
         _BookShelf.transform.position =
            Vector3.Lerp(_BookShelf.transform.position, MoveTo.position, Smoothing * Time.deltaTime); 
      }
      
   }


  
}
