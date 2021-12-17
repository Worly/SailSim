using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailRotation : MonoBehaviour
{
    [SerializeField]
    public Wind wind;

    [SerializeField]
    public SailTrimInput sailTrimInput;

    [SerializeField]
    public float rotationWhenFullyLoose;

    [SerializeField]
    public float sailAngularAcceleration;

    [SerializeField]
    public float sailAngularDeceleration;

    private float sailRotationSpeed = 0;

    public void Update()
    {
        var force = Vector3.Dot(wind.WindDirectionVector, -transform.right);

        sailRotationSpeed += force * sailAngularAcceleration * Mathf.Pow(wind.WindSpeed, 2) * Time.deltaTime;

        transform.rotation *= Quaternion.AngleAxis(sailRotationSpeed * Time.deltaTime, transform.up);

        // friction
        sailRotationSpeed -= sailRotationSpeed * sailAngularDeceleration * Time.deltaTime;

        ApplyTrimming();
    }

    private void ApplyTrimming()
    {
        var maxAbsoluteRotation = (1 - sailTrimInput.Tightness) * rotationWhenFullyLoose;

        // transform y rotation which is <-infinity, +infinity> to <-180, 180> where 0 is parallel to the boat
        var sailAngleFromBoat = transform.localRotation.eulerAngles.y;
        sailAngleFromBoat += 180;
        sailAngleFromBoat %= 360;
        sailAngleFromBoat -= 180;

        // if angle is greater than trimming angle, reset rotation speed and limit rotation angle
        if (Mathf.Abs(sailAngleFromBoat) >= maxAbsoluteRotation)
        {
            transform.localRotation = Quaternion.AngleAxis(maxAbsoluteRotation * Mathf.Sign(sailAngleFromBoat), transform.up);
            sailRotationSpeed = 0;
        }
    }
}
