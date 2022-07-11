using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTransform : MonoBehaviour
{
    #region Variables
    private Vector3 scale;

    #endregion

    #region Unity Methods
    void Start()
    {
        scale = transform.localScale;
    }

    private void OnMouseExit()
    {
        transform.localScale = scale;
    }

    private void OnMouseUp()
    {
        transform.localScale = scale;
        transform.localScale *= 1.05f;
    }
    #endregion
}
