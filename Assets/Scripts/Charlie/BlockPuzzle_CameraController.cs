using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BlockPuzzle_CameraController : MonoBehaviour
{
   
    public GameObject[] cameraPositions;

    public List<Boolean> cubeBools;
    // Start is called before the first frame update
    void Awake()
    {
        cameraPositions = GameObject.FindGameObjectsWithTag("camera pos");
    }

    

    public int index;

    private void Update()
    {
        UP();
        DOWN();
        transform.position = cameraPositions[index].transform.position;
    }
    
    void UP()
    {
        if (!down && Input.GetKeyUp(KeyCode.Tab))
        {
            index++;
            //Debug.Log("UP");
            if (index > 3)
            {
                index = 3;
                down = true;
                
            }
        } 
    }

    private bool down;
    void DOWN()
    {
        if (down && Input.GetKeyUp(KeyCode.Tab))
        {
            //Debug.Log("DOWN");
            index--;
            if (index == 0)
            {
                down = false;
            }
        }
    }

    
}
