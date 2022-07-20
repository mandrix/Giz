using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBirds : MonoBehaviour
{
    static int inactiveBirds;
    [SerializeField]
    private GameObject birdSpot;
    [SerializeField]
    private SceneFlow flow;
    [SerializeField]
    private bool isActive = false;
    [SerializeField]
    private static bool end = false;
    static bool ready = false;
    private void Start()
    {
        ready = false;
        inactiveBirds += 1;
    }
    private void Update()
    {
        if (end)
        {
            gameObject.SetActive(false);
        }   
    }
    public void SetEnd()
    {
        end = true;
    }
    public void SetReady()
    {
        ready = true;
    }
    private void OnMouseUp()
    {
        if (!ready || isActive)
        {
            return;
        }
        isActive = true;
        inactiveBirds -= 1;
        Debug.Log(inactiveBirds);
        if (inactiveBirds == 0)
        {
            ready = false;
            flow.transform.GetComponent<GameFlowLvl6>().DeactivateAllUi();
            flow.ActivateInfoUI();
            transform.GetComponent<OnlyOneMove>().SetDestination(birdSpot.transform.position);
            transform.GetComponent<AnimalRotateInfo>().RotateWithFunction();
        }
    }
}
