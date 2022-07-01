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
        Debug.Log(transform.position + "  ffff  " + leafSpot.transform.position);
        ready = false;
        Debug.Log(inactiveTrees);
        inactiveTrees += 1;
    }
    public void SetReady()
    {
        Debug.Log(inactiveTrees);
        ready = true;
    }
    private void OnMouseUp()
    {
        Debug.Log(inactiveTrees);
        if (!ready || isActive)
        {
            return;
        }
        isActive = true;
        inactiveTrees -= 1;
        Debug.Log(inactiveTrees);
        treeInfo.SetActive(true);
        if (inactiveTrees == 0)
        {
            Debug.Log("entra");
            ready = false;
            leaf.SetActive(true);
            flow.ActivateInfoUI();
            Debug.Log(transform.position +"  ffff  " + leafSpot.transform.position);
            //leaf.transform.GetComponent<OnlyOneMove>().SetDestinationAndStart(transform.position, leafSpot.transform.position);
            leaf.GetComponent<AnimalRotateInfo>().RotateWithFunction();
        }
    }
}
