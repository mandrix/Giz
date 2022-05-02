using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HourText : MonoBehaviour
{
    public Text hourText;    
   
    void Update()
    {
        hourText.text = DateTime.Now.ToLongTimeString();
    }
}
