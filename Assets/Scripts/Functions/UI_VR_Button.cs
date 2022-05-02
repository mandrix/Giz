using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class UI_VR_Button : MonoBehaviour
{
    public int[] functionsIndex;
    // Start is called before the first frame update
    void Start()
    {
        foreach (int f in functionsIndex)
        {
            UnityEvent customEvent = UI_VR_Ctrl.Instance.functions.EventList[f];
            this.GetComponent<Button>().onClick.AddListener(() =>
            {
                customEvent.Invoke();
            });
        }
    }
}
