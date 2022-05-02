using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextTrivia : MonoBehaviour
{
    [Header("Question objects")]
    public GameObject[] imageOptions;
    public int maxSelectableOptions;
    public int currentSelectedOptions;

    //QUITAR LUEGO
    [Header("Answer checker")]
    public bool completed = false;

    public bool lastTrivia;
    public GameObject[] questionObjects;

    public Sprite triviaBackground;
    public Sprite wrongBackground;
    public Sprite goodBackground;
    public Image triviaImage;

    public GameObject triviaPanel;
    public GameObject wrongPanel;
    public GameObject goodPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentSelectedOptions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectImage() {
        currentSelectedOptions++;

        if (currentSelectedOptions == maxSelectableOptions) {
            for (int i = 0; i < imageOptions.Length; i++)
            {
                imageOptions[i].GetComponent<Button>().interactable = false;
            }

            //QUITAR DESPUES
            if (!completed) {
                StartCoroutine(AppearAnswer());
            }            
        }
    }

    IEnumerator AppearAnswer() {
        yield return new WaitForSeconds(0.5f);
        ActivateFinalPanel();
    }

    public void CheckAnswers() {
        //QUITAR DESPUES
        if (completed) {
            bool userAnsweredCorrectly = true;
            for (int i = 0; i < imageOptions.Length; i++)
            {
                if (imageOptions[i].transform.GetChild(4).gameObject.activeInHierarchy) {
                    if (!(imageOptions[i].transform.GetChild(5).GetComponent<Image>().enabled)) {
                        userAnsweredCorrectly = false;
                        i = imageOptions.Length;
                    }                    
                }               
            }
            if (userAnsweredCorrectly && currentSelectedOptions == maxSelectableOptions)
            {
                //Contesta correctamente
                if (lastTrivia)
                {
                    //Es la ultima trivia
                }
                StartCoroutine(AppearAnswer());
                    
            }
            else {
                //Contesta incorrectamente
                StartCoroutine(BadAnswer());



            }

        }
    }

    IEnumerator BadAnswer()
    {
        yield return new WaitForSeconds(0.5f);
        ActivateBadPanel();
    }

    public void ActivateFinalPanel()
    {        
        triviaImage.sprite = goodBackground;
        goodPanel.SetActive(true);
        triviaPanel.SetActive(false);
    }

    public void ActivateBadPanel()
    {
        triviaImage.sprite = wrongBackground;
        wrongPanel.SetActive(true);
        triviaPanel.SetActive(false);
    }

    public void ResetTrivia()
    {
        goodPanel.SetActive(false);
        wrongPanel.SetActive(false);
        triviaPanel.SetActive(true);
        triviaImage.sprite = triviaBackground;

        //Volver a aparecer trivia
        for (int i = 0; i < questionObjects.Length; i++)
        {
            questionObjects[i].SetActive(true);
        }        

        //Reactivar funcion de los botones
        for (int i = 0; i < imageOptions.Length; i++)
        {
            imageOptions[i].GetComponent<Button>().interactable = true;            
        }

        //Reiniciar cuenta de respuestas
        currentSelectedOptions = 0;

        //Quitar los elementos de la respuesta
        for (int i = 0; i < imageOptions.Length; i++)
        {
            imageOptions[i].transform.GetChild(2).gameObject.SetActive(false);             
            imageOptions[i].transform.GetChild(4).gameObject.SetActive(false);             
            imageOptions[i].transform.GetChild(5).gameObject.SetActive(false);             
            imageOptions[i].transform.GetChild(6).gameObject.SetActive(false);             
        }
    }
}
