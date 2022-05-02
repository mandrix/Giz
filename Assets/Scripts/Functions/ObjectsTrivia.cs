using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectsTrivia : MonoBehaviour
{
    
    [Header("Question objects")]
    public GameObject[] objectOptions;
    public int maxSelectableOptions;
    public int currentSelectedOptions;
    public GameObject answerText;
    public GameObject nextButton;


    //QUITAR LUEGO
    [Header("Answer checker")]
    public bool completed = false;

    public bool lastTrivia;
    public GameObject[] questionObjects;
    public GameObject triviaAnswers;
    private GameObject buttonToFinal;
    private GameObject buttonToBad;
    public GameObject badAnswerText;

    // Start is called before the first frame update
    void Start()
    {
        currentSelectedOptions = 0;
        buttonToFinal = triviaAnswers.transform.GetChild(0).gameObject;
        buttonToBad = triviaAnswers.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectImage() {
        currentSelectedOptions++;
        if (currentSelectedOptions == maxSelectableOptions) {

            CheckAnswers();

            for (int i = 0; i < objectOptions.Length; i++)
            {
                objectOptions[i].GetComponent<Button>().interactable = false;
            }

            //QUITAR DESPUES
            if (!completed)
            {
                StartCoroutine(AppearAnswer());
            }
        }
    }

    IEnumerator AppearAnswer() {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < objectOptions.Length; i++)
        {
            objectOptions[i].transform.GetChild(1).gameObject.SetActive(true);
            objectOptions[i].transform.GetChild(4).gameObject.SetActive(true);
            objectOptions[i].transform.GetChild(5).gameObject.SetActive(true);

        }

        // QUITAR DESPUES
        if (!completed)
        {
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            if (lastTrivia)
            {
                buttonToFinal.SetActive(true);
            }
            else {
                nextButton.gameObject.SetActive(true);
            }
            
        }


        answerText.gameObject.SetActive(true);
    }

    private void CheckAnswers()
    {
        //QUITAR DESPUES
        if (completed)
        {
            bool userAnsweredCorrectly = true;
            for (int i = 0; i < objectOptions.Length; i++)
            {
                if (objectOptions[i].transform.GetChild(3).gameObject.activeInHierarchy)
                {
                    if (!(objectOptions[i].transform.GetChild(4).GetComponent<Image>().enabled))
                    {
                        userAnsweredCorrectly = false;
                        i = objectOptions.Length;
                    }
                }
            }
            if (userAnsweredCorrectly)
            {
                //Contesta correctamente
                if (lastTrivia)
                {
                    //Es la ultima trivia
                    triviaAnswers.SetActive(true);
                }                
                StartCoroutine(AppearAnswer());

            }
            else
            {
                //Contesta incorrectamente
                triviaAnswers.SetActive(true);
                StartCoroutine(BadAnswer());



            }

        }
    }

    IEnumerator BadAnswer()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < objectOptions.Length; i++)
        {
            objectOptions[i].transform.GetChild(1).gameObject.SetActive(false);
            objectOptions[i].transform.GetChild(2).gameObject.SetActive(false);
            objectOptions[i].transform.GetChild(3).gameObject.SetActive(false);
            objectOptions[i].transform.GetChild(4).gameObject.SetActive(false);
            objectOptions[i].transform.GetChild(5).gameObject.SetActive(false);
        }
        buttonToBad.SetActive(true);
        badAnswerText.gameObject.SetActive(true);

    }

    public void ActivateFinalPanel()
    {
        triviaAnswers.SetActive(true);
        triviaAnswers.transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 0; i < questionObjects.Length; i++)
        {
            questionObjects[i].SetActive(false);
        }
        nextButton.gameObject.SetActive(true);
    }

    public void ActivateBadPanel()
    {
        triviaAnswers.SetActive(true);
        triviaAnswers.transform.GetChild(2).gameObject.SetActive(true);
        for (int i = 0; i < questionObjects.Length; i++)
        {
            questionObjects[i].SetActive(false);
        }
    }

    public void ResetTrivia()
    {

        //Volver a aparecer trivia
        questionObjects[0].SetActive(true);
        questionObjects[1].SetActive(true);

        questionObjects[2].SetActive(false);
        questionObjects[3].SetActive(false);

        //Reactivar funcion de los botones
        for (int i = 0; i < objectOptions.Length; i++)
        {
            objectOptions[i].GetComponent<Button>().interactable = true;
        }

        //Reiniciar cuenta de respuestas
        currentSelectedOptions = 0;

        //Quitar los elementos de la respuesta
        for (int i = 0; i < triviaAnswers.transform.childCount; i++)
        {
            triviaAnswers.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
