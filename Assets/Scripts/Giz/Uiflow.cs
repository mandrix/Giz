using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uiflow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject menuUI;
    [SerializeField]
    private GameObject instructionUI;
    [SerializeField]
    private GameObject selecterLvl;
    [SerializeField]
    private GameObject panelGris;
    [SerializeField]
    private GameObject shade;
    #endregion


    #region Unity Methods
    void Start()
    {
        shade.SetActive(true);
        ActivatePanelGris();
    }
    #endregion



    #region Custom Methods

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }


    private void DeactivateAllUi()
    {
        instructionUI.SetActive(false);
        menuUI.SetActive(false);
        panelGris.SetActive(false);
        selecterLvl.SetActive(false);
        shade.SetActive(false);
    }

    public void ActivateInstruccion()
    {
        Debug.Log("intruc");
        DeactivateAllUi();
        shade.SetActive(true);
        instructionUI.SetActive(true);
    }

    public void ActivateMenuUi()
    {
        Debug.Log("lvl selecter");
        DeactivateAllUi();
        menuUI.SetActive(true);
    }
    public void ActivatePanelGris()
    {
        Debug.Log("lvl selecter");
        DeactivateAllUi();
        shade.SetActive(true);
        panelGris.SetActive(true);
    }

    public void ActivateSelecterLvl()
    {
        Debug.Log("lvl selecter");
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    #endregion


}
