using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject menuUI;
    [SerializeField]
    private GameObject group1;
    [SerializeField]
    private GameObject silhouette1;
    [SerializeField]
    private GameObject buttonAcceptSilhouettes1;
    [SerializeField]
    private GameObject group2;
    [SerializeField]
    private GameObject silhouette2;
    [SerializeField]
    private GameObject buttonAcceptSilhouettes2;
    [SerializeField]
    private GameObject instructionUI;
    [SerializeField]
    public GameObject nextPhase;
    [SerializeField]
    private int step = 0;

    #endregion


    #region Unity Methods
    void Start()
    {
        menuUI.SetActive(true);
    }
    #endregion


    #region Custom Methods
    public int GetStep()
    {
        return step;
    }
    private void DeactivateAllUi()
    {
        instructionUI.SetActive(false);
        menuUI.SetActive(false);
        group1.SetActive(false);
        group2.SetActive(false);
        silhouette1.SetActive(false);
        silhouette2.SetActive(false);
        buttonAcceptSilhouettes1.SetActive(false);
        buttonAcceptSilhouettes2.SetActive(false);
        panel.SetActive(false);
        nextPhase.SetActive(false);
    }

    public void ActivateSilhouette1()
    {
        Debug.Log("sil1");
        step = 1;
        DeactivateAllUi();
        buttonAcceptSilhouettes1.SetActive(true);
        silhouette1.SetActive(true);
    }

    public void ActivateGroup1()
    {
        Debug.Log("g1");
        DeactivateAllUi();
        group1.SetActive(true);
    }

    public void ActivateSilhouette2()
    {
        Debug.Log("sil2");
        step = 2;
        DeactivateAllUi();
        buttonAcceptSilhouettes2.SetActive(true);
        silhouette2.SetActive(true);
    }

    public void ActivateGroup2()
    {
        Debug.Log("g1");
        DeactivateAllUi();
        group2.SetActive(true);
    }

    public void ActivateInstruccion()
    {
        Debug.Log("intruc");
        DeactivateAllUi();
        instructionUI.SetActive(true);
    }
    #endregion


}
