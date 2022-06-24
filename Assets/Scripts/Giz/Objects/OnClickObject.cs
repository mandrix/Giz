using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickObject : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;
    [SerializeField]
    private SceneFlow script;
    private void OnMouseUp()
    {
        if (isCorrect)
        {
            script.gameObject.GetComponent<GameFlowLvl1>().StopScene();
            script.ActivateInfoUI();
        }
    }
}
