using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTraps : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inverse = false;
    public void Rotate()
    {
        inverse = true;
        iTween.RotateBy(gameObject, iTween.Hash("x", -0.17, "loopType", "None", "delay", -0.2, "time", 1));
    }
    public void RotateInverse()
    {
        inverse = false;
        iTween.RotateBy(gameObject, iTween.Hash("x", 0.17, "loopType", "None", "delay", -0.2, "time", 1));
    }
}
