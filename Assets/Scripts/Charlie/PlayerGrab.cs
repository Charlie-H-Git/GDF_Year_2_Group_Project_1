using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerGrab : MonoBehaviour
{
    public Camera _camera;
    private Vector3 point = new Vector3();
    private Vector3 mousePos;
    
    [Range(0,5)]public float dist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //point = _camera.ViewportPointToRay();
        //Ray grabcheck = new Ray(gameObject.transform.position, mousePos * dist);
        Debug.DrawRay(gameObject.transform.position,(point - gameObject.transform.position) * 10, Color.red);
    }
}
