using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] public Transform target;
    [SerializeField] private float distanceToTarget = 10;
    public Vector3 targetpos;
    private Vector3 direction;
    private Vector3 previousPosition;
    bool first = true;

    private void Start()
    {
        cam = Camera.main;
        targetpos = target.position;
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (target != null && first)
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            direction = previousPosition - newPosition;
            cam.transform.position = targetpos;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
            first = false;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
             direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = targetpos;
            
            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
       

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distanceToTarget = distanceToTarget + 1;
            cam.transform.position = targetpos;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
       else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distanceToTarget = distanceToTarget - 1;
            cam.transform.position = targetpos;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
    }
}