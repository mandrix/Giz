using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnt : MonoBehaviour
{
    [SerializeField]
    private TutorialFlow tutorial;


    private void OnMouseUp()
    {
        tutorial.ActivateFinalUi();
    }
}
