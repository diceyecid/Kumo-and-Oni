using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = .5f;

    public Vector3 offset;

    private Vector3 velocity;

    public float maxZoom = 18f;
    public float minZoom = 12f;
    public float zoomLimter = 18f;

    public Camera cam;


    public float shakeAmount = 0f;
    public float decreaseFactor = 1.0f;
    public bool shake;
    public float shakeTime = 10;
    private Vector3 orginalpos;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        if (shake == false)
        {
            Move();
            Zoom();
        }

        else
        {
            if (shakeTime > 0)
            {
                transform.localPosition = new Vector3(orginalpos.x + Random.Range(-0.1f, 0.1f), orginalpos.y + Random.Range(-0.1f, 0.1f), orginalpos.z);
                shakeTime -= Time.deltaTime;
            }
            else
            {
                shakeTime = 3f;
                this.transform.localPosition = orginalpos;
                shake = false;
            }

        }
    }

        void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        orginalpos = transform.position;
    }

    void Zoom()
    {
        //Debug.Log(GetGreatestDistance());

        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/ zoomLimter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i =0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    
}
