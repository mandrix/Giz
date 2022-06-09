using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameFlowLvl1 : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    [SerializeField]
    private AudioSource firstAudio;
    [SerializeField]
    private GameObject[] invertebratesList;
    [SerializeField]
    public GameObject infoUi;
    [SerializeField]
    public GameObject finalUi;
    [SerializeField]
    private AudioSource finalAudio;
    [SerializeField]
    private GameObject selecterLvl;
    #endregion

    #region Unity Methods
    void Start()
    {
        firstAudio.Play();
        StartCoroutine(ActivateAInvertebrate(0));
        DeactivateAllUi();
    }
    #endregion



    #region Custom Methods
    private void DeactivateAllUi()
    {
        selecterLvl.SetActive(false);
        infoUi.SetActive(false);
        finalUi.SetActive(false);
    }
    public void ActivateSelecterLvl()
    {
        Debug.Log("lvl selecter");
        DeactivateAllUi();
        selecterLvl.SetActive(true);
    }
    public void ActivateInfoUI()
    {
        DeactivateAllUi();
        finalAudio.Play();
        infoUi.SetActive(true);
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

    private void Activate(int index)
    {
        Debug.Log("entra2;");
        
    }

    private IEnumerator ActivateAInvertebrate(int index)
    {
        Debug.Log("entra");
        yield return new WaitForSeconds(5);
        if (invertebratesList.Length > index)
        {
            Debug.Log(index);
            invertebratesList[index].SetActive(true);
            StartCoroutine(ActivateAInvertebrate(index + 1));
        }
    }
    #endregion


}
