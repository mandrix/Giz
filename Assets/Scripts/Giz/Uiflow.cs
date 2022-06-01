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

    #endregion


    #region Unity Methods
    void Start()
    {
        menuUI.SetActive(true);
    }
    #endregion



    #region Custom Methods

    public void ChangeScene()
    {
        SceneManager.LoadScene("Giz3D");
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
    #endregion


}
