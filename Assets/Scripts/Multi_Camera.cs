using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Multi_Camera : MonoBehaviour
{
    [SerializeField] List<Transform> targets_to_frame;
    [SerializeField] Vector3 offset;
    [SerializeField] float minzoom = 40f, maxZoom = 80f;
    float zoomoffset;
    Vector3 centerpoint;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets_to_frame.Count == 0)
            return;

        centerpoint = getcenterpoint() + offset;
        transform.LookAt(centerpoint);

        zoomoffset = Vector3.Distance(targets_to_frame[0].position, targets_to_frame[1].position) * 2;
        cam.fieldOfView = Mathf.Clamp(zoomoffset, minzoom, maxZoom);
    }

    Vector3 getcenterpoint()
    {
        if (targets_to_frame.Count == 1)
            return targets_to_frame[0].position;

        var bounds = new Bounds(targets_to_frame[0].position, Vector3.one);

        foreach (Transform targets in targets_to_frame)
            bounds.Encapsulate(targets.position);

        return bounds.center;
    }
}
