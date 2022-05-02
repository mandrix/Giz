using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flecha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(transform.position - Vector3.up * 0.05f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
