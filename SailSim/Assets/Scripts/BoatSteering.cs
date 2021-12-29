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
    public float rotationSpeed;

    public void Update()
    {
        var currentRotation = transform.rotation.eulerAngles;

        var rotationChange = rudderInput.Rotation * boatMovement.CurrentSpeed * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y + rotationChange, currentRotation.z);
    }
}
