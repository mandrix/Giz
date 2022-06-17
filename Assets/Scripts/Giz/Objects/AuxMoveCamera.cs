using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxMoveCamera : MonoBehaviour
{
    [SerializeField]
    private CameraZoom cam;

    private void OnMouseUp()
    {
        cam.ActivateMove();
    }
}
