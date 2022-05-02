using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EPOOutline;

public class Dinamica03 : MonoBehaviour
{

    public List<BoxBed> beds;
    public GameObject electricPalletPosition;
    public GameObject answer;
    public GameObject products;
    public UnityEvent answerEvent;

    public float objectHigh;
    public GameObject selectedObject;
    public List<int> selectedProducts;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < beds.Count; i++) {
            beds[i].dinamica = this;
        }
    }

    IEnumerator ShowAnswers()
    {
        yield return new WaitForSeconds(5f);

        bool correctAnswer = true;
        for(int i = 0; i < selectedProducts.Count; i++) {
            if(selectedProducts[i] != i) {
                correctAnswer = false;
                break;
            }
        }

        if(correctAnswer){
            answer.transform.GetChild(0).gameObject.SetActive(true);
            answer.transform.GetChild(1).gameObject.SetActive(false);
        }
        else {
            answer.transform.GetChild(1).gameObject.SetActive(true);
            answer.transform.GetChild(0).gameObject.SetActive(false);
        }
        answerEvent.Invoke();
    }

    public void ProductSelected(BoxBed product) {
        selectedProducts.Add(product.type);
        if(selectedProducts.Count==5){
            StartCoroutine(ShowAnswers());
        }
    }

    public void Reset() {
        selectedProducts.Clear();
        for(int i = 0; i < beds.Count; i++) {
            beds[i].Reset();
        }
    }
}
