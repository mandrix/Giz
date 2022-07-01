using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOneMove : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    private float timeToReachTarget = 10;

    private float t;
    private bool ready = false;
    public Vector3 startPosition;
    public Vector3 target;
    void Start()
    {
        startPosition = target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            Debug.Log("d");
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
        
    }

    public void SetDestination(Vector3 destination)
    {
        t = 0;
        startPosition = transform.position;
        target = destination;
        ready = true;
    }
    public void SetDestinationAndStart(Vector3 start, Vector3 destination)
    {
        t = 0;
        startPosition = start;
        target = destination;
        ready = true;
    }
}
