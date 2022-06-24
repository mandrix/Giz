using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameFlowLvl1 : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private GameObject[] invertebratesList;
    [SerializeField]
    private GameObject phaseZoom;
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject indicacion2;
    [SerializeField]
    private bool stop = false;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
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
    public void ActivateScene()
    {
        stop = false;
        DeactivateAllUi();
        StartCoroutine(ActivateAInvertebrate(0));
    }

    public void StopScene()
    {
        stop = true;
    }

    private IEnumerator ActivateAInvertebrate(int index)
    {
        yield return new WaitForSeconds(5);

        if (invertebratesList.Length > index && !stop)
        {
            Debug.Log(index);
            invertebratesList[index].SetActive(true);
            StartCoroutine(ActivateAInvertebrate(index + 1));
            }
    }
    #endregion


}
