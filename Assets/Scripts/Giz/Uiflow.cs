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

    #endregion


    #region Unity Methods
    void Start()
    {
        menuUI.SetActive(true);
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
    }

    public void ActivateInstruccion()
    {
        Debug.Log("intruc");
        DeactivateAllUi();
        instructionUI.SetActive(true);
    }
    public void ActivateSelecterLvl()
    {
        Debug.Log("lvl selecter");
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    #endregion


}
