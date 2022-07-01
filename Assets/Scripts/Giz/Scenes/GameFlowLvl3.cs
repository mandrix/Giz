using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowLvl3 : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    private GameObject transecto;
    [SerializeField]
    private ActiveTreeInfo tree;
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
        flow.ActivateUI(indicacion1);
       
    }
    public void ActivateIndicacion2()
    { 
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[1];
        audioManager.Play();
        flow.ActivateUI(indicacion2);
    }
    public void ActivateScene()
    {
        DeactivateAllUi();
        tree.SetReady();
    }
    #endregion


}
