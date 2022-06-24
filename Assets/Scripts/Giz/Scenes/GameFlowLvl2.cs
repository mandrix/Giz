using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowLvl2 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject indicacion1;
    [SerializeField]
    private GameObject traps;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    #endregion

    #region Unity Methods
    #endregion

    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[0];
        audioManager.Play();
        indicacion1.SetActive(true);
    }

    #region Custom Methods
    public void ActivateTraps()
    {
        DeactivateAllUi();
        traps.SetActive(true);
    }
    public void DeactivateAllUi()
    {
        indicacion1.SetActive(false);
        traps.SetActive(false);

    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    #endregion


}
