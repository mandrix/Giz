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
    [SerializeField]
    private GameObject pivotUi; // ayuda para setear el UI
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
        NextAudio();
        ActivateUI(welcomeUI);
    }
    public void ActivateWelcome2()
    {
        DeactivateAllUi();
        NextAudio();
        ActivateUI(welcomeUI2);
    }
    public void ActivateWelcome3()
    {
        DeactivateAllUi();
        NextAudio();
        ActivateUI(welcomeUI3);
    }
    public void ActivateInfoUI()
    {

        DeactivateAllUi();
        NextAudio();
        ActivateUI(InfoUi);
    }
    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        NextAudio();
        ActivateUI(indicacion1);
    }
    public void ActivateAnimal()
    {
        DeactivateAllUi();
        animal.GetComponent<TutorialAnt>().setFlag();
    }
    public void ActivateIndicacion2()
    {
        DeactivateAllUi();
        NextAudio();
        ActivateUI(indicacion2);
    }
    public void ActivateFinalUi()
    {
        DeactivateAllUi();
        NextAudio();
        ActivateUI(finalUi);
    }
    private void NextAudio()
    {
        audioManager.clip = audioList.AudiosList[indexAudio];
        indexAudio++;
        audioManager.Play();
    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    public void ActivateUI(GameObject ui)
    {
        DeactivateAllUi();
        Quaternion rotate = pivotUi.transform.rotation;
        Vector3 position = pivotUi.transform.position;
        rotate.x = 0;
        rotate.z = 0;
        position.y = ui.transform.position.y;
        ui.transform.SetPositionAndRotation(position, rotate);
        ui.SetActive(true);
    }
    public void ActivatePhaseTutorialCamera()
    {
        DeactivateAllUi();
        tutorialCamera.SetReady();
    }
    #endregion


}

