﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    [Range(0,5)]
    private float timeToReachTarget = 1;

    [SerializeField]
    private bool move = false;
    private float t;
    Vector3 startPosition;
    public Vector3 target;
    static bool alreadyMove = false; 
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
        else {
            target = obj.transform.position;
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(transform.position, startPosition, t);
        }
    }

    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }

    private void OnMouseUp()
    {
        Debug.Log("move");
        if (!alreadyMove)
        {
            startPosition = transform.position;
            /*transform.SetParent(obj.transform);
            transform.position = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = new Quaternion(0, 0, 0, 0);*/
            t = 0;
            move = true;
            alreadyMove = true;
        }
        else if (move)
        {
            t = 0;
            alreadyMove = move = false;
        }

        /*
        switch (loopType)
        {
            case "p":
                loopType = "pingPong";
                break;
            case "l":
                loopType = "loop";
                break;
            default:
                loopType = "none";
                break;
        }
        Debug.Log(obj.transform.position.x + " " + obj.transform.position.y + " " + +obj.transform.position.z);
        Debug.Log(gameObject.transform.position.x + " " + gameObject.transform.position.y + " " + gameObject.transform.position.z);
        float x = obj.transform.position.x - transform.position.x;
        float y = obj.transform.position.y - transform.position.y;
        float z = obj.transform.position.z - transform.position.z;
        Debug.Log(x + " " + y + " " + z);
        */
        // iTween.MoveBy(gameObject, iTween.Hash("x", 0, "y", 10, "z", -22.5f, "easeType", "easeInOutExpo", "loopType", loopType, "delay", .1, "time", time));
    }
}
