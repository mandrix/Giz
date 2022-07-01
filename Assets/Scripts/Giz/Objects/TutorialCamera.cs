using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCamera : MonoBehaviour
{
    [SerializeField]
    private Quaternion rotation;
    [SerializeField]
    private TutorialFlow tutorial;
    [SerializeField]
    private bool ready = true;
    void Start()
    {
        
    }

    public void SetReady()
    {
        rotation = transform.rotation;
        ready = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(rotation != transform.rotation && !ready)
        {
            ready = true;
            StartCoroutine(CameraReady());
       
        }
    }

    private IEnumerator CameraReady()
    {
        yield return new WaitForSeconds(5);
        tutorial.ActivateIndicacion2();
    }
}
