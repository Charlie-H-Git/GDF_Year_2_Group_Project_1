using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
[System.Serializable]
public enum Directions
{
    up,
    down,
    left,
    right,
    forward,
    back
}

public class AlphabetBlock : MonoBehaviour
{
    public BlockPuzzle_CameraController BP_CC;
    private Vector3 xPlus = new Vector3(90, 0, 0);
    private Vector3 yPlus = new Vector3(0, 90, 0);
    private Vector3 xMinus = new Vector3(-90, 0, 0);
    private Vector3 yMinus = new Vector3(0, -90, 0);
    public GameObject[] blocks;
    public Directions directions;
    public Vector3[] vectorList = new[]
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right,
        Vector3.forward,
        Vector3.back,
    };

    public int index;
    private void Awake()
    {
         index = (int) directions;
    }

    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag("Cube");
        
    }

    void PosCheck()
    {
        
        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.TransformDirection((vectorList[index] * 6)));
        if (Physics.Raycast(gameObject.transform.position,gameObject.transform.TransformDirection((vectorList[index] * 6)), out hit))
        {
            if (hit.collider.CompareTag("Block1"))
            {
                BP_CC.cubeBools[0] = true;
            }
            if (hit.collider.CompareTag("Block2"))
            {
                BP_CC.cubeBools[1] = true;
            }
            if (hit.collider.CompareTag("Block3"))
            {
                BP_CC.cubeBools[2] = true;
            }
            if (hit.collider.CompareTag("Block4"))
            {
                BP_CC.cubeBools[3] = true;
            }
        }
    }

    
    private void Update()
    {
        PosCheck();

        if (Input.GetKeyDown(KeyCode.A))
        {
            blocks[BP_CC.index].gameObject.transform.Rotate(yMinus * Time.deltaTime,Space.Self);
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            blocks[BP_CC.index].gameObject.transform.Rotate(yPlus * Time.deltaTime,Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            blocks[BP_CC.index].gameObject.transform.Rotate(xPlus * Time.deltaTime,Space.Self);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            blocks[BP_CC.index].gameObject.transform.Rotate(xMinus * Time.deltaTime,Space.Self);
        }
        
        
    }
}
