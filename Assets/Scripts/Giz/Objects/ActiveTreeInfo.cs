using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTreeInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject treeInfo;
    [SerializeField]
    private GameObject leaf;
    [SerializeField]
    private GameObject leafSpot;
    static int inactiveTrees;
    [SerializeField]
    private SceneFlow flow;
    [SerializeField]
    private bool isActive = false;
    static bool ready = false;
    private void Start()
    {
        ready = false;
        inactiveTrees += 1;
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
        inactiveTrees -= 1;
        treeInfo.SetActive(true);
        if (inactiveTrees == 0)
        {
            ready = false;
            leaf.SetActive(true);
            flow.transform.GetComponent<GameFlowLvl3>().DeactivateAllUi();
            flow.ActivateInfoUI();
            //leaf.transform.GetComponent<OnlyOneMove>().SetDestinationAndStart(transform.position, leafSpot.transform.position);
            leaf.GetComponent<AnimalRotateInfo>().RotateWithFunction();
        }
    }
}
