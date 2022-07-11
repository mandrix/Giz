using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameFlowLvl5 : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private GameObject[] invertebratesList;
    [SerializeField]
    private OnlyOneMove cameraMove;
    [SerializeField]
    private GameObject pivotCamera;
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    private GameObject indicacion3;
    [SerializeField]
    private GameObject indicacion3Text;
    [SerializeField]
    private GameObject frog;
    [SerializeField]
    private bool stop = false;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    [SerializeField]
    private SceneFlow flow;
    [SerializeField]
    private string newInstructionText;
    #endregion


    #region Custom Methods
    public void ActivatePhaseMovement()
    {
        DeactivateAllUi();
        StartCoroutine(cameraMove.TimeUp(this));
        cameraMove.SetDestination(pivotCamera.transform.position);
        frog.GetComponent<FrogHandling>().SetReady(true);
    }

    public void DeactivateAllUi()
    {
        indicacion1.SetActive(false);
        indicacion2.SetActive(false);
        indicacion3.SetActive(false);
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
        flow.ActivateUI(indicacion2);
        audioManager.Play();
    }
    public void ActivateIndicacion3()
    {
        Debug.Log(2);
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[2];
        int frogTotal = frog.GetComponent<FrogHandling>().GetTotalFrogs();
        int howFrogsActivated = frog.GetComponent<FrogHandling>().GetTotalFrogsActivated();
        frog.GetComponent<FrogHandling>().SetStart();
        newInstructionText = "Has terminado el recorrido y has encontrado: " + howFrogsActivated + " rana(s) de " + frogTotal + " que habían en total en el río.";
        indicacion3Text.GetComponent<TextMeshProUGUI>().text = newInstructionText;
        flow.ActivateUI(indicacion3);
        audioManager.Play();
    }

    public void StopScene()
    {
        stop = true;
    }
    #endregion
}
