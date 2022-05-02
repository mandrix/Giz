using UnityEngine;

public class MouseRotateObject : MonoBehaviour
{
    private Camera m_currentCamera;
    private Transform m_transform;
    private DesktopController desktop_controller;
    private Vector3 m_screenPoint;
    private Vector3 m_offset;
    public float rotationVelocity;
    bool gazeInteraction;
    Vector3 point;

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        desktop_controller = FindObjectOfType<DesktopController>();
    }

    void OnMouseDown()
    {
        m_currentCamera = FindCamera();
        if (m_currentCamera != null)
        {
            desktop_controller.interacting = true;
            m_screenPoint = GetMousePosWithScreenZ(m_screenPoint.z);
            m_offset = gameObject.transform.position - m_currentCamera.ScreenToWorldPoint(GetMousePosWithScreenZ(m_screenPoint.z));
        }
    }

    void OnMouseUp()
    {
        desktop_controller.interacting = false;
        m_currentCamera = null;
    }

    public void InitGazeInteraction(Vector3 hitPoint)
    {
        point = hitPoint;
        gazeInteraction = true;
    }

    public void FinishGazeInteraction()
    {
        gazeInteraction = false;
    }

    void FixedUpdate()
    {
        if (gazeInteraction)
        {
            float horizontal = transform.position.x - point.x;
            if (horizontal != 0) m_transform.Rotate(new Vector3(0, 1, 0), Mathf.Sign(horizontal) * 0.5f);
        }
        else if (m_currentCamera != null)
        {
            Vector3 currentScreenPoint = GetMousePosWithScreenZ(m_screenPoint.z);
            float horizontal = currentScreenPoint.x - m_screenPoint.x;
            if (horizontal != 0) m_transform.Rotate(new Vector3(0, 1, 0), -horizontal * rotationVelocity);
        }
    }

    Vector3 GetMousePosWithScreenZ(float screenZ)
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenZ);
    }

    Camera FindCamera()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
        Camera result = null;
        int camerasSum = 0;
        foreach (var camera in cameras)
        {
            if (camera.enabled)
            {
                result = camera;
                camerasSum++;
            }
        }
        if (camerasSum > 1)
        {
            result = null;
        }
        return result;
    }
}
