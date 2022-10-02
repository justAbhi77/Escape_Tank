using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Mutiple_Target_Cam : MonoBehaviour
{
    [SerializeField] List<Transform> targets_to_frame;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothtime = .5f, minZoom = 40f, maxZoom = 10, zoomLimit = 60f;
    Vector3 velocity, centerpoint;
    Camera cam;
    float newzoom;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        centerpoint = getcenterpoint();

        transform.position = Vector3.SmoothDamp(transform.position, centerpoint + offset, ref velocity, smoothtime);

        Zoom();
    }

    void Zoom()
    {
        newzoom = Mathf.Lerp(maxZoom, minZoom, getgreatest() / zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newzoom, Time.deltaTime);
    }

    float getgreatest()
    {
        var bounds = new Bounds(targets_to_frame[0].position, Vector3.one);

        foreach (Transform targets in targets_to_frame)
            bounds.Encapsulate(targets.position);

        float dis=Mathf.Pow(bounds.size.x,2)+Mathf.Pow(bounds.size.z,2);

        return dis;
    }

    Vector3 getcenterpoint()
    {
        if (targets_to_frame.Count == 1)
            return targets_to_frame[0].position;

        var bounds = new Bounds(targets_to_frame[0].position, Vector3.zero);

        foreach (Transform targets in targets_to_frame)
            bounds.Encapsulate(targets.position);

        return bounds.center;
    }
}
