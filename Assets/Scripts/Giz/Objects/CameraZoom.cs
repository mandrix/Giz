using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameFlowLvl1 flow;
    [SerializeField]
    [Range(0, 5)]
    private float timeToReachTarget = 1;

    private bool move = false;
    private float t;
    Vector3 startPosition;
    [SerializeField]
    private Vector3 target;
    void Start()
    {
        startPosition = target = transform.position;

    }
    void Update()
    {
        if (move)
        {
            target = obj.transform.position;
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
    }

    public void ActivateMove()
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = 1;
        move = true;
        flow.ActivateIndicacion2();
    }

}
