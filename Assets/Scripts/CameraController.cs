using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraTarget;
    public Vector3 offset;
    public float smoothSpeed = 10.0f;


    private void Start() {


    }

    private void Update() {

        
    }

    private void LateUpdate() {
        Vector3 newPosition = cameraPosition.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(cameraTarget.position);
    }
}

