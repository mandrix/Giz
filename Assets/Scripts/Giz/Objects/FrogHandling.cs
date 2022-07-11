using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogHandling : MonoBehaviour
{
    
    static private int totalFrogs = 0;
    static private int totalFrogsActivated = 0;
    static bool ready = false;
    [SerializeField]
    private bool isActive = false;
    private void Start()
    {
        totalFrogs += 1;
    }
    private void OnMouseUp()
    {
        if (!ready || isActive)
        {
            return;
        }
        Debug.Log(totalFrogs + " "+ totalFrogsActivated);
        isActive = true;
        totalFrogsActivated += 1;
    }
    public void SetReady(bool setReady)
    {
        ready = setReady;
    }
    public int GetTotalFrogs()
    {
        return totalFrogs;
    }
    public int GetTotalFrogsActivated()
    {
        return totalFrogsActivated;
    }
    public void SetStart()
    {
        totalFrogs = 0;
        totalFrogsActivated = 0;
    }
}
