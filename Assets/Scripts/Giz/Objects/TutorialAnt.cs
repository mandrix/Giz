using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnt : MonoBehaviour
{
    [SerializeField]
    private TutorialFlow tutorial;
    [SerializeField]
    private bool flag = false;
    [SerializeField]
    private GameObject spot;


    private void OnMouseUp()
    {
        if (flag)
        {
            tutorial.ActivateInfoUI();
            GetComponent<OnlyOneMove>().SetDestination(spot.transform.position);
            transform.SetParent(spot.transform);
            transform.position = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            flag = false;
        }
        
    }

    public void setFlag()
    {
        flag = true;
    }
}
