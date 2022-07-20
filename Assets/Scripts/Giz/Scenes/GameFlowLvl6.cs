using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowLvl6 : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private GameObject bird;
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

    public void DeactivateAllUi()
    {
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
    public void ActivateScene()
    {
        DeactivateAllUi();
        bird.GetComponent<ActivateBirds>().SetReady();
    }


    #endregion


}
