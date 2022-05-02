using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class UI_VR_Text : MonoBehaviour{
    
    public int textIndex;

    // Start is called before the first frame update
    void Start()
    {        
        this.GetComponent<Text>().text = UI_VR_Ctrl.Instance.textsTemplate.texts[textIndex];
    }    
}
