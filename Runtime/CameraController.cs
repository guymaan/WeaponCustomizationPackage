using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Options")]
    [SerializeField] private float cameraSpeed;
    [SerializeField] private int distanceFromCam;

    public GameObject target;
    private Vector3 previousPos;
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }


    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Weapon");
        }
        

        if (target != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);

            }

            if (Input.GetMouseButton(0))
            {
                Vector3 dir = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);

                cam.transform.position = target.transform.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), dir.y * cameraSpeed);
                cam.transform.Rotate(new Vector3(0, 1, 0), -dir.x * cameraSpeed, Space.World);
                cam.transform.Translate(new Vector3(0, 0, distanceFromCam));

                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
        }
    }
}
