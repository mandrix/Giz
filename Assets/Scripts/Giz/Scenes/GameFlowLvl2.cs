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
    private GameObject trap;
    [SerializeField]
    private GameObject animal;
    [SerializeField]
    private AudioSource audioManager;
    [SerializeField]
    private DinamicAudios audioList;
    [SerializeField]
    private SceneFlow flow;
    #endregion

    #region Unity Methods
    #endregion

    public void ActivateIndicacion1()
    {
        DeactivateAllUi();
        audioManager.clip = audioList.AudiosList[0];
        audioManager.Play();
        flow.ActivateUI(indicacion1);
    }

    #region Custom Methods
    public void ActivateTraps()
    {
        DeactivateAllUi();
        trap.GetComponent<AnimalResult>().SetReady();
        trap.GetComponent<Trap>().SetReady();
        trap.GetComponent<MoveToObject>().ToggleReady();
    }
    public void DeactivateAllUi()
    {
        indicacion1.SetActive(false);

    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    #endregion

    public void DeactiveAnimal()
    {
        animal.SetActive(false);
    }
}
