using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveSilhouette : MonoBehaviour
{
    #region Variables
    public Silhouette silhouette;
    public GameFlow gameFlow;

    private Vector3 scale;

    #endregion

    #region Unity Methods
    void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        
    }

    private void OnMouseExit()
    {
        transform.localScale = scale;
    }

    private void OnMouseUp()
    {
        transform.localScale = scale;
        transform.localScale *= 1.05f;
        gameFlow.CheckAnswer(silhouette.id);    
       
        //ui.GetComponentsInChildren<TMP_Text>()[0].text = silhouette.description;
    }
    #endregion
}
