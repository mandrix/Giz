using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dinamica02 : MonoBehaviour
{

    public List<Pallet> pallets;
    public List<Pallet> definedAsGoodPallets;
    public List<Pallet> definedAsBadPallets;
    public GameObject initialPile;
    public GameObject goodPile;
    public GameObject badPile;
    public GameObject interactionPoint;
    public Pallet selectedPallet;
    public GameObject answer;
    public UnityEvent answerEvent;
    public FadeCtrl interactionUI;

    public float palletHigh;
    public GameObject selectedObject;

    public void RandomizeArray(List<Pallet> arr)
    {
        for (var i = arr.Count - 1; i > 0; i--) {
            var r = Random.Range(0,i);
            var tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeArray(pallets);
        for(int i = 0; i < pallets.Count; i++) {
            pallets[i].gameObject.transform.parent = initialPile.transform;
            pallets[i].gameObject.transform.localRotation = Quaternion.identity;
            pallets[i].gameObject.transform.position = initialPile.transform.position + Vector3.up * palletHigh * (i);
            pallets[i].dinamica = this;
        }
        StartCoroutine(ActivateNextPallet());
    }

    public void DefineSelectedAsGood() {
        selectedPallet.DefineAsGood(definedAsGoodPallets.Count);
        definedAsGoodPallets.Add(selectedPallet);
        pallets.Remove(selectedPallet);
        NextPallet();
    }

    public void DefineSelectedAsBad() {
        selectedPallet.DefineAsBad(definedAsBadPallets.Count);
        definedAsBadPallets.Add(selectedPallet);
        pallets.Remove(selectedPallet);
        NextPallet();
    }

    private void NextPallet() {
        interactionUI.FadeOut();
        StartCoroutine(DeactivateInteractionUI());
        if(pallets.Count > 0) {
            StartCoroutine(ActivateNextPallet());
        }
        else {
            StartCoroutine(ShowAnswers());
        }
    }

    IEnumerator DeactivateInteractionUI()
    {
        yield return new WaitForSeconds(0.5f);
        interactionUI.gameObject.SetActive(false);
    }

    IEnumerator ActivateNextPallet()
    {
        yield return new WaitForSeconds(0.6f);
        pallets[pallets.Count - 1].GetComponent<BoxCollider>().enabled = true;
        pallets[pallets.Count - 1].gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator ShowAnswers()
    {
        yield return new WaitForSeconds(1.5f);

        bool correctAnswer = true;

        for(int i = 0; i < definedAsGoodPallets.Count; i++) {
            if(!definedAsGoodPallets[i].good) correctAnswer = false;
        }
        for(int i = 0; i < definedAsBadPallets.Count; i++) {
            if(definedAsBadPallets[i].good) correctAnswer = false;
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

    public void Reset() {
        for(int i = 0; i < definedAsGoodPallets.Count; i++) {
            pallets.Add(definedAsGoodPallets[i]);
        }
        for(int i = 0; i < definedAsBadPallets.Count; i++) {
            pallets.Add(definedAsBadPallets[i]);
        }
        definedAsGoodPallets.Clear();
        definedAsBadPallets.Clear();
        
        RandomizeArray(pallets);
        for(int i = 0; i < pallets.Count; i++) {
            pallets[i].gameObject.transform.parent = initialPile.transform;
            pallets[i].gameObject.transform.localRotation = Quaternion.identity;
            pallets[i].gameObject.transform.position = initialPile.transform.position + Vector3.up * palletHigh * i;
        }
        StartCoroutine(ActivateNextPallet());
    }
}
