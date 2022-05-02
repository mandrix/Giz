using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EPOOutline;

public class BoxBed : MonoBehaviour
{

    public List<Vector3> initialPositions;
    public List<Vector3> initialRotations;
    public List<Transform> boxes;
    public Dinamica03 dinamica;
    public int type;
    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < 4; i++) {
        Transform child = transform.GetChild(i);
        boxes.Add(child);
        initialPositions.Add(child.position);
        initialRotations.Add(child.rotation.eulerAngles);
      }  
    }

    public void InitGazeInteraction () {
      TryToSelect();
    }

    void TryToSelect() {
      if(!selected) {
        dinamica.ProductSelected(this);
        int index = dinamica.selectedProducts.Count;
        
        GetComponent<Outlinable>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        selected = true;

        for(int i = 0; i < 4; i++) {
          Transform child = transform.GetChild(0);
          Sequence outSequence = DOTween.Sequence();
          Vector3 localPosition = child.localPosition;
          child.parent = dinamica.electricPalletPosition.transform;
          outSequence.Append(child.transform.DOMove(child.position, 0.3f * i));
          outSequence.Append(child.transform.DOMove(child.position - Vector3.forward * 1f, 0.5f).OnComplete(() => {
              child.transform.DOLocalRotate(new Vector3(0, 180, 0), 1);
          }
          ));
          outSequence.Append(child.transform.DOLocalMove(localPosition + Vector3.up * 6 * dinamica.objectHigh, 1));
          outSequence.Append(child.transform.DOLocalMove(localPosition + Vector3.up * index * dinamica.objectHigh, 0.5f));
        }        
      }
    }

    void OnMouseDown()
    {
      TryToSelect();
    }

    public void Reset() {
      for(int i = 0; i < 4; i++) {
        Transform child = boxes[i];
        child.parent = transform;
        child.position = initialPositions[i];
        child.rotation = Quaternion.Euler(initialRotations[i]);
      }
      gameObject.transform.GetComponent<Outlinable>().enabled = true;
      gameObject.transform.GetComponent<BoxCollider>().enabled = true;
      selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
