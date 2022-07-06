using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameFlow : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject silhouette;
    [SerializeField]
    private Image silhouetteUI;
    [SerializeField]
    private GameObject instructionText;
    [SerializeField]
    public GameObject infoUi;
    [SerializeField]
    public GameObject infoText;
    [SerializeField]
    public GameObject infoBtnEspecieText;
    [SerializeField]
    public GameObject infoBtnGroupText;
    [SerializeField]
    public GameObject infoTitle;
    [SerializeField]
    public GameObject infoSpriteTitle;
    [SerializeField]
    public GameObject infoSpriteEspecieBtn;
    [SerializeField]
    public GameObject infoSpriteGroupBtn;
    [SerializeField]
    public GameObject finalUi;
    [SerializeField]
    private int step = 0;
    [SerializeField]
    private int rounds;
    [SerializeField]
    private Silhouette[] silhouetteList;
    [SerializeField]
    private AudioSource audioWin;
    [SerializeField]
    private AudioSource audioLose;
    [SerializeField]
    private bool isTest = false;
    [SerializeField]
    private string newInstructionText;
    [SerializeField]
    private GameObject pivotUi;


    #endregion


    #region Unity Methods
    void Start()
    {
        ActivateSilhouette();
    }

    #endregion


    #region Custom Methods
    public int GetStep()
    {
        return step;
    }


    public void CheckAnswer(int answer)
    {
        if (silhouetteList[step].id == answer)
        {
            isTest = false;
            ActivateInfoAnimalUi();
            if (isTest)
            {
                //audioLose.clip = ;
                audioLose.Play();
            }
        }
        else if (isTest)
        {
            audioLose.Play();
        }

    }

    public void NextStep(){
        step +=1;
    }

    private void DeactivateAllUi()
    {
        infoUi.SetActive(false);
        silhouette.SetActive(false);
        panel.SetActive(false);
    }

    public void ActivateInfoAnimalUi()
    {   
        infoBtnEspecieText.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].especie;
        infoBtnGroupText.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].group;
        infoSpriteEspecieBtn.GetComponent<Image>().sprite = silhouetteList[step].especieIcono;
        infoSpriteGroupBtn.GetComponent<Image>().sprite = silhouetteList[step].groupIcono;
        ActivateInfoEspecie();
        ActivateUI(infoUi);
    }

    public void ActivateInfoEspecie(){
        infoSpriteTitle.GetComponent<Image>().sprite = silhouetteList[step].especieIcono;
            infoText.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].especieDescription;
            infoTitle.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].especie;
         
    }

    public void ActivateInfoGruop(){
        infoSpriteTitle.GetComponent<Image>().sprite = silhouetteList[step].groupIcono;
            infoText.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].groupDescription;
            infoTitle.GetComponent<TextMeshProUGUI>().text = silhouetteList[step].group;
         
    }

    private void ActivateUI(GameObject ui)
    {
        DeactivateAllUi();
        ui.transform.SetPositionAndRotation(pivotUi.transform.position, pivotUi.transform.rotation);
        ui.SetActive(true);
    }
    public void ActivateSilhouette()
    {
        if (step >= rounds)
        {
            ActivateUI(finalUi);
        }
        else
        {
            newInstructionText = "Enfoca tu busqueda en el grupo " + silhouetteList[step].group + " y la especie " + silhouetteList[step].especie + ".";
            Debug.Log(instructionText);
            Debug.Log(instructionText.GetComponent<TextMeshProUGUI>());
            Debug.Log(instructionText.GetComponent<TextMeshProUGUI>().text);
            instructionText.GetComponent<TextMeshProUGUI>().text = newInstructionText;
            silhouetteUI.GetComponent<Image>().sprite = silhouetteList[step].silhouette;
            ActivateUI(silhouette);
        }
    }






    public void ActivateTest()
    {

        DeactivateAllUi();
        isTest = true;
    }

    public void ActivateInstruccion()
    {
        DeactivateAllUi();
        
    }
    #endregion


}
