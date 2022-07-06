using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRotateInfo : MonoBehaviour
{
    private void OnMouseUp()
    {
        iTween.RotateBy(gameObject, iTween.Hash("y", 10, "loopType", "Loop", "delay", -0.2, "time", 400));
    }
    public void RotateWithFunction()
    {
        iTween.RotateBy(gameObject, iTween.Hash("y", 10, "loopType", "Loop", "delay", -0.2, "time", 400));
    }
}
