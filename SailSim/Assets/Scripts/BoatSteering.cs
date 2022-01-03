using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSteering : MonoBehaviour
{
    [SerializeField]
    public RudderInput rudderInput;

    [SerializeField]
    public BoatMovement boatMovement;

    [SerializeField]
    public float rudderDistance;

    public void Update()
    {
        var currentRotation = transform.rotation.eulerAngles;


        var rudderRadian = rudderInput.Rotation * Mathf.PI / 180;

        var turningRadius = rudderDistance / Mathf.Tan(rudderRadian);

        var angularVelocity = boatMovement.CurrentSpeed / turningRadius * 180 / Mathf.PI;

        var rotationChange = angularVelocity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y + rotationChange, currentRotation.z);
    }
}
