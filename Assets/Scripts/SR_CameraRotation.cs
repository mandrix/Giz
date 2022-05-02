using UnityEngine;
using System.Collections;

//Turn off from main camera for VR mode

public class SR_CameraRotation : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;


    void Start()
    {

    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);        
#endif
    }
}
