using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFlow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject welcomeUI;
    [SerializeField]
    private GameObject welcomeUI2;
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    public GameObject InfoUi; // esta info sera para cada escena por aparte dependiendo del grupo/especie
    [SerializeField]
    private GameObject finalUi;
    [SerializeField]
    private GameObject animal;
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
        InfoUi.SetActive(false);
        welcomeUI.SetActive(false);
        welcomeUI2.SetActive(false);
        finalUi.SetActive(false);
    }

    public void ActivateWelcome()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[0];
        audioManager.Play();
        welcomeUI.SetActive(true);
    }
    public void ActivateWelcome2()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[1];
        audioManager.Play();
        welcomeUI2.SetActive(true);
    }
    public void ActivateInfoUI()
    {

        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[2];
        audioManager.Play();
        InfoUi.SetActive(true);
    }
    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[2];
        audioManager.Play();
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
        audioManager.clip = audioList.AudiosList[3];
        audioManager.Play();
        indicacion2.SetActive(true);
    }
    public void ActivateFinalUi()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[4];
        audioManager.Play();
        finalUi.SetActive(true);
    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    public void ActivatePhaseTutorialCamera()
    {
        DeactivateAllUi();
        tutorialCamera.SetReady();
    }
    #endregion


}
