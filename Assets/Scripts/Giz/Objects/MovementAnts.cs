using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnts : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    [Range(0, 5)]
    private float timeToReachTarget = 1;

    [SerializeField]
    private bool move = false;
    private float t;
    Vector3 startPosition;
    public Vector3 target;
    private bool stop = false;
    void Start()
    {
        startPosition = target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            target = obj.transform.position;
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }
        
    }


    public void StopMovement()
    {
        stop = true;
    }
    public void SetDestination(GameObject destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        obj = destination;
    }
}
