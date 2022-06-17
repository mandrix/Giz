using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFlow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject welcomeUI;
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    private GameObject finalUi;
    [SerializeField]
    private GameObject animal;
    [SerializeField]
    private GameObject shade;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    [SerializeField]
    private TutorialCamera tutorialCamera;
    #endregion

    private void Start()
    {
        ActivateWelcome();
    }

    #region Custom Methods

    public void DeactivateAllUi()
    {
        indicacion1.SetActive(false);
        indicacion2.SetActive(false);
        shade.SetActive(false);
        animal.SetActive(false);
        welcomeUI.SetActive(false);
        finalUi.SetActive(false);
    }

    public void ActivateWelcome()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[0];
        audioManager.Play();
        shade.SetActive(true);
        welcomeUI.SetActive(true);
    }
    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[1];
        audioManager.Play();
        shade.SetActive(true);
        indicacion1.SetActive(true);
    }
    public void ActivateAnimal()
    {
        DeactivateAllUi();
        animal.SetActive(true);
    }
    public void ActivateIndicacion2()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[2];
        audioManager.Play();
        shade.SetActive(true);
        indicacion2.SetActive(true);
    }
    public void ActivateFinalUi()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[3];
        audioManager.Play();
        shade.SetActive(true);
        finalUi.SetActive(true);
    }
    public void ActivatePhaseTutorialCamera()
    {
        DeactivateAllUi();
        tutorialCamera.SetReady();
    }
    #endregion


}
