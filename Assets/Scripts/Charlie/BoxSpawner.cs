using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class BoxSpawner : MonoBehaviour
{
    public GameObject cube;

    [SerializeField]private float spawnDelay = 2;
    [SerializeField] private float spawnAmount = 10f;
    private Vector3 position = new Vector3(-17.37f ,33.1f,-38.7f);
   

    private void Awake()
    {
        StartCoroutine("cubeCoroutine");
    }

    IEnumerator cubeCoroutine()
    {
        
        for (int i = 0; i < spawnAmount; i++ )
        {
            Instantiate(cube, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        } 
    }
}
