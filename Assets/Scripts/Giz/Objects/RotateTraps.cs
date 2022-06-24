using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTraps : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inverse = false;
    private void OnMouseUp()
    {
        if (inverse)
        {
            RotateInverse();
            inverse = false;
        }
        else
        {
            Rotate();
            inverse = true;
        }
    }
    public void Rotate()
    {
        iTween.RotateBy(gameObject, iTween.Hash("x", -0.1, "loopType", "None", "delay", -0.2, "time", 1));
    }
    public void RotateInverse()
    {
        iTween.RotateBy(gameObject, iTween.Hash("x", 0.1, "loopType", "None", "delay", -0.2, "time", 1));
    }
}
