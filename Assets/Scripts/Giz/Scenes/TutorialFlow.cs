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
    private GameObject welcomeUI3;
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
    [SerializeField]
    private int indexAudio = 0;
    #endregion

    private void Start()
    {
        ActivateWelcome2();
    }

    #region Custom Methods

    public void DeactivateAllUi()
    {
        indicacion1.SetActive(false);
        indicacion2.SetActive(false);
        InfoUi.SetActive(false);
        welcomeUI.SetActive(false);
        welcomeUI2.SetActive(false);
        welcomeUI3.SetActive(false);
        finalUi.SetActive(false);
    }

    public void ActivateWelcome()
    {
        DeactivateAllUi();
        nextAudio();
        welcomeUI.SetActive(true);
    }
    public void ActivateWelcome2()
    {
        DeactivateAllUi();
        nextAudio();
        welcomeUI2.SetActive(true);
    }
    public void ActivateWelcome3()
    {
        DeactivateAllUi();
        nextAudio();
        welcomeUI3.SetActive(true);
    }
    public void ActivateInfoUI()
    {

        DeactivateAllUi();
        nextAudio();
        InfoUi.SetActive(true);
    }
    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        nextAudio();
        indicacion1.SetActive(true);
    }
    public void ActivateAnimal()
    {
        DeactivateAllUi();
        animal.GetComponent<TutorialAnt>().setFlag();
    }
    public void ActivateIndicacion2()
    {
        DeactivateAllUi();
        nextAudio();
        indicacion2.SetActive(true);
    }
    public void ActivateFinalUi()
    {
        DeactivateAllUi();
        nextAudio();
        finalUi.SetActive(true);
    }
    private void nextAudio()
    {
        audioManager.clip = audioList.AudiosList[indexAudio];
        indexAudio++;
        audioManager.Play();
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

