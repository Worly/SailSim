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
    public BoatMovement boatMovement;

    [SerializeField]
    public bool applyApparentWindDirection;

    [SerializeField]
    public float apparentWindFactor;

    [SerializeField]
    public float rotationWhenFullyLoose;

    [SerializeField]
    public float sailAngularAcceleration;

    [SerializeField]
    public float sailAngularDeceleration;

    public Vector3 SailForward { get => transform.forward; }
    public Vector3 SailRight { get => transform.right; }

    private float sailRotationSpeed = 0;

    public void Update()
    {
        var trueWindDirection = wind.WindDirectionVector * wind.WindSpeed;

        var apparentWindDirection = -boatMovement.transform.forward * boatMovement.CurrentSpeed * apparentWindFactor;

        var windDirection = trueWindDirection;

        var windSailAngle = (wind.WindDirection - transform.rotation.eulerAngles.y + 360) % 360;
        if (windSailAngle >= 90 && windSailAngle < 270 &&  applyApparentWindDirection)
            windDirection += apparentWindDirection;

        var dragPercentage = Vector3.Dot(windDirection.normalized, -transform.right);

        sailRotationSpeed += dragPercentage * sailAngularAcceleration * Mathf.Pow(wind.WindSpeed, 2) * Time.deltaTime;

        transform.localRotation *= Quaternion.AngleAxis(sailRotationSpeed * Time.deltaTime, Vector3.up);

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
            transform.localRotation = Quaternion.AngleAxis(maxAbsoluteRotation * Mathf.Sign(sailAngleFromBoat), Vector3.up);
            sailRotationSpeed = 0;
        }
    }
}
