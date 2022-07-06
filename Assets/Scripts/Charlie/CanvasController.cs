using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text Text;

    private string _string1 = ("Press F To Turn Flashlight On/Off");

    private string _string2 = ("Pres E To Interact With Objects");

    private string _string3 = ("Find All 4 Fuses To turn On The Lights");
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        Text.text = _string1;
        yield return new WaitForSeconds(5);
        Text.text = _string2;
        yield return new WaitForSeconds(5);
        Text.text = _string3;
        yield return new WaitForSeconds(10);
        yield return null;

    }
}
