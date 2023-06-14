using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField] private Vector2 multiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start(){
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate(){
        Vector3 deltaMOvement = cameraTransform.position - lastCameraPosition;
        transform.position +=new Vector3(deltaMOvement.x * multiplier.x,deltaMOvement.y);
        lastCameraPosition = cameraTransform.position;
    }
}
