using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool LightOn = false;
    public bool safeguard = false;
    public GameObject lightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (LightOn == false && safeguard == false)
            {
                safeguard = true;
                lightSource.SetActive(true);
                LightOn = true;
                StartCoroutine(safeGuard());
            }

            if (LightOn == true && safeguard == false)
            {
                safeguard = true;
                lightSource.SetActive(false);
                LightOn = false;
                StartCoroutine(safeGuard());
            }
        }
    }

    IEnumerator safeGuard()
    {
        yield return new WaitForSeconds(0.25f);
        safeguard = false;
    }
}
