using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class UI_VR_Image : MonoBehaviour{
    
    public int imageIndex;

    // Start is called before the first frame update
    void Start()
    {        
        this.GetComponent<Image>().sprite = UI_VR_Ctrl.Instance.imagesTemplate.images[imageIndex];
    }    
}
