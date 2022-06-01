using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectError : MonoBehaviour
{
    #region Variables
    
    public AudioSource m_MyAudioSource;

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
        Debug.Log(222);
        transform.localScale = scale;
        transform.localScale *= 1.05f;
        m_MyAudioSource.Play();
        //ui.GetComponentsInChildren<TMP_Text>()[0].text = silhouette.description;
    }
    #endregion
}
