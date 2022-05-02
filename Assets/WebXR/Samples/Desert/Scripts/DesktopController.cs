using UnityEngine;
using WebXR;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class DesktopController : MonoBehaviour {
    [Tooltip("Enable/disable rotation control. For use in Unity editor only.")]
    public bool rotationEnabled = true;

    [Tooltip("Enable/disable translation control. For use in Unity editor only.")]
    public bool translationEnabled = true;

    private WebXRDisplayCapabilities capabilities;

    [Tooltip("Mouse sensitivity")]
    public float mouseSensitivity = 1f;

    [Tooltip("Straffe Speed")]
    public float straffeSpeed = 5f;

    private float minimumX = -360f;
    private float maximumX = 360f;

    private float minimumY = -90f;
    private float maximumY = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    Quaternion originalRotation;
    public bool interacting = false;

    float MouseZoomSpeed = 15.0f;
    float TouchZoomSpeed = 0.1f;
	float ZoomMinBound = 34f;
	float ZoomMaxBound = 60f;
    private Camera cam;
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle = 0;
    float yAngle = 0;
    float xAngleTemp;
    float yAngleTemp;

    [DllImport("__Internal")]

    private static extern bool IsMobile();
 
    public bool isMobile()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
        #endif
        return false;
    }
    void Start()
    {
        WebXRManager.OnXRChange += onXRChange;
        WebXRManager.OnXRCapabilitiesUpdate += onXRCapabilitiesUpdate;
        originalRotation = transform.localRotation;
        cam = GetComponent<Camera>();
    }

    private void onXRChange(WebXRState state, int viewsCount, Rect leftRect, Rect rightRect)
    {
        if (state == WebXRState.NORMAL)
        {
            DisableEverything();
        }
        else
        {
            EnableAccordingToPlatform();
        }
    }

    private void onXRCapabilitiesUpdate(WebXRDisplayCapabilities vrCapabilities)
    {
        capabilities = vrCapabilities;
        EnableAccordingToPlatform();
    }

    void Update() {
        if (!isMobile())
        {
            /*if (translationEnabled)
            {
                float x = Input.GetAxis("Horizontal") * Time.deltaTime * straffeSpeed;
                float z = Input.GetAxis("Vertical") * Time.deltaTime * straffeSpeed;

                transform.Translate(x, 0, z);
            }*/

            if (rotationEnabled && Input.GetMouseButton(0) && !interacting)
            {

                rotationX += Input.GetAxis ("Mouse X") * mouseSensitivity;
                rotationY += Input.GetAxis ("Mouse Y") * mouseSensitivity;

                rotationX = ClampAngle (rotationX, minimumX, maximumX);
                rotationY = ClampAngle (rotationY, minimumY, maximumY);

                Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.down);
                Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.right);

                transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, -MouseZoomSpeed);
            
        }
        else {
            if (Input.touchSupported)
            {
                // Handle screen touches.
                if (Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);

                    if(touch.phase == TouchPhase.Began && !interacting){
                        FirstPoint = Input.GetTouch(0).position;
                        xAngleTemp = xAngle;
                        yAngleTemp = yAngle;
                    }
                    if(touch.phase == TouchPhase.Moved && !interacting){
                        SecondPoint = Input.GetTouch(0).position;
                        xAngle = xAngleTemp - (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                        yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                    }
                }else if (Input.touchCount == 2)
                {
                    // get current touch positions
                    Touch tZero = Input.GetTouch(0);
                    Touch tOne = Input.GetTouch(1);
                    // get touch position from the previous frame
                    Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                    Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                    float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                    float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                    // get offset value
                    float deltaDistance = oldTouchDistance - currentTouchDistance;
                    Zoom(deltaDistance, -TouchZoomSpeed);
                }
            }
        }
       
    }

    void DisableEverything()
    {
        translationEnabled = false;
        rotationEnabled = false;
    }

    /// Enables rotation and translation control for desktop environments.
    /// For mobile environments, it enables rotation or translation according to
    /// the device capabilities.
    void EnableAccordingToPlatform()
    {
        rotationEnabled = translationEnabled = !capabilities.canPresentVR;
    }

    public static float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp (angle, min, max);
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.fieldOfView += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
    }
}
