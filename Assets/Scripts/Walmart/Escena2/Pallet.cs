using UnityEngine;
using DG.Tweening;

public class Pallet : MonoBehaviour
{
    public bool good = false;
    public bool selected = false;
    public Dinamica02 dinamica;

    void Awake()
    {
        
    }

    public void InitGazeInteraction () {
      TryToSelect();
    }

    void TryToSelect() {
      if(!selected) {
        gameObject.transform.DOMove(dinamica.interactionPoint.transform.position, 1);
        gameObject.GetComponent<MouseRotateObject>().enabled = true;
        selected = true;
        dinamica.selectedPallet = this;
        dinamica.interactionUI.gameObject.SetActive(true);
        dinamica.interactionUI.FadeIn();
        transform.GetChild(0).gameObject.SetActive(false);
      }
    }

    void OnMouseDown()
    {
      TryToSelect();
    }

    public void DefineAsGood(int index) {
      selected = false;
      gameObject.transform.parent = dinamica.goodPile.transform;
      gameObject.transform.DOLocalRotate(Vector3.zero, 1);
      gameObject.transform.DOMove(dinamica.goodPile.transform.position + Vector3.up * (index * dinamica.palletHigh), 1);
      gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void DefineAsBad(int index) {
      selected = false;
      gameObject.transform.parent = dinamica.badPile.transform;
      gameObject.transform.DOLocalRotate(Vector3.zero, 1);
      gameObject.transform.DOMove(dinamica.badPile.transform.position + Vector3.up * (index * dinamica.palletHigh), 1);
      gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    void OnMouseUp()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
