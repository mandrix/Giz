using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowLvl4 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject phaseZoom;
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    [SerializeField]
    private SceneFlow flow;
    #endregion


    #region Custom Methods
    public void ActivatePhaseZoom()
    {
        DeactivateAllUi();
        phaseZoom.SetActive(true);
    }

    public void DeactivateAllUi()
    {
        phaseZoom.SetActive(false);
        indicacion1.SetActive(false);
        indicacion2.SetActive(false);
    }

    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[0];
        audioManager.Play();
        indicacion1.SetActive(true);
    }
    public void ActivateIndicacion2()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[1];
        audioManager.Play();
        indicacion2.SetActive(true);
    }
    public void Activate()
    {
        DeactivateAllUi();
    }
    public void ActivateIndicacion3()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[2];
        audioManager.Play();
        indicacion2.SetActive(true);
    }
    public void ActivateScene()
    {
        DeactivateAllUi();
    }
    #endregion


}
