using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

[Serializable]


public class KeyScrip : MonoBehaviour
{
    public TMPro.TMP_Text textField;

    public int passCode = 1337;
    
    public void Enter()
    {
        int.TryParse(textField.text, out int result);

        
        if (result == passCode)
        {
            //TODO: DO SOMETHING
            print("Correct");
        }
        else
        {
            textField.text = "INCORRECT";
            print("Incorrect");
            textField.text = "";
        }
    }
    
    public void Cancel()
    {
        textField.text = "";
    }
    public void button1()
    {
        textField.text = textField.text + "1";
    }
    
    public void button2()
    {
        textField.text = textField.text + "2";
    }
    
    public void button3()
    {
        textField.text = textField.text + "3";
    }
    
    public void button4()
    {
        textField.text = textField.text + "4";
    }
    
    public void button5()
    {
        textField.text = textField.text + "5";
    }
    
    public void button6()
    {
        textField.text = textField.text + "6";
    }
    
    public void button7()
    {
        textField.text = textField.text + "7";
    }
    
    public void button8()
    {
        textField.text = textField.text + "8";
    }
    
    public void button9()
    {
        textField.text = textField.text + "9";
    }
    
    public void button0()
    {
        textField.text = textField.text + "0";
    }
}
