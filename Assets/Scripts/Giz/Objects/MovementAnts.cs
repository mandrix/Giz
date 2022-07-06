using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnts : MonoBehaviour
{
    [SerializeField]
    private GameObject antHill;
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    [Range(0, 5)]
    private float timeToReachTarget = 1;

    private float t;
    Vector3 startPosition;
    public Vector3 target;
    void Start()
    {
        startPosition = target = transform.position;
        target = antHill.transform.position;
    }

    private void OnMouseUp()
    {
            startPosition = transform.position;
            transform.SetParent(obj.transform);
            transform.position = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            target = obj.transform.position;
            t = 0;
    }

    // Update is called once per frame
    void Update()
    {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
    }

    public void SetDestination(GameObject destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        antHill = destination;
    }
}
