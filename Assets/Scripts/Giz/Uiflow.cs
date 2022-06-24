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
    private GameObject selecterLvl;
    [SerializeField]
    private GameObject panelGris;
    #endregion


    #region Unity Methods
    void Start()
    {
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
        menuUI.SetActive(false);
        panelGris.SetActive(false);
        selecterLvl.SetActive(false);
    }
    public void ActivateMenuUi()
    {
        DeactivateAllUi();
        menuUI.SetActive(true);
    }
    public void ActivatePanelGris()
    {
        DeactivateAllUi();
        panelGris.SetActive(true);
    }

    public void ActivateSelecterLvl()
    {
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    #endregion


}
