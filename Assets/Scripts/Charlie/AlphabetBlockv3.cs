using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetBlockv3 : MonoBehaviour
{

    public Transform reference;

    public GameObject cube;

    
    //public Vector3 dir  //cube.transform.position
    public Vector3[] vectorList = new[]
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right,
        Vector3.forward,
        Vector3.back,
    };
    // Start is called before the first frame update
    enum Directions
    {
        up,
        down,
        left,
        right,
        forward,
        back
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
