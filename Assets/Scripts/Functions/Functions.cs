using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Functions : MonoBehaviour
{
    [Header("Start event")]
    public UnityEvent startEvent;

    [Header("Event list")]
    public List<UnityEvent> EventList;

    public void Start()
    {
        startEvent.Invoke();       
    }
}
