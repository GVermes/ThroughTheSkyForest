using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    [SerializeField] List<Transform> targets;
    [SerializeField] float smoothTime;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;
    [SerializeField] Camera mainCam;
    [SerializeField] Transform camRig;

    Vector3 velocity;
    float zoomLimit = 20f;
    bool followY = true;
    Vector3 tempY;
    float camYPos;

    public static CamScript camScript;


    private void Start()
    {
        camScript = this;
        camYPos = camRig.transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i <targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint;
        newPosition.y = camYPos;
        transform.position = newPosition;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetMaximumDistance() / zoomLimit);
        mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetMaximumDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

}
