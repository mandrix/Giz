using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFlow : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private Audios audioList; //all audios
    [SerializeField]
    public GameObject firstInfoUi;
    [SerializeField]
    public GameObject InfoUi;
    [SerializeField]
    public GameObject finalUi;
    [SerializeField]
    public AudioSource audioManager;
    [SerializeField]
    private AudioSource finalAudio;
    [SerializeField]
    private GameObject selecterLvl;
    [SerializeField]
    private int sceneIndex;
    #endregion

    #region Unity Methods
    void Start()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.getFirstAudio(sceneIndex);
        audioManager.Play();        
    }
    #endregion

    #region Custom Methods
    private void DeactivateAllUi()
    {
        selecterLvl.SetActive(false);
        firstInfoUi.SetActive(false);
        InfoUi.SetActive(false);
        finalUi.SetActive(false);
    }
    public void ActivateSelecterLvl()
    {
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    public void ActivateInfoUI()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.getFinalAudio(sceneIndex);
        audioManager.Play();
        InfoUi.SetActive(true);
    }
    public void ActivateFinalUI()
    {
        DeactivateAllUi();
        finalUi.SetActive(true);

    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    #endregion

}
