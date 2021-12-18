using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRoll : MonoBehaviour
{
    [SerializeField]
    public Wind wind;

    [SerializeField]
    public SailRotation sailRotation;

    [SerializeField]
    public float keelWeight;

    [SerializeField]
    public float sailDragForce;

    [SerializeField]
    public float angularDeceleration;

    private float rollRotationSpeed = 0;

    public void Update()
    {
        var sailWindDotProduct = Mathf.Abs(Mathf.Clamp(Vector3.Dot(wind.WindDirectionVector, -sailRotation.SailRight), -1, 1));

        var dragPercentage = (Mathf.Acos(sailWindDotProduct) * Mathf.Rad2Deg - 90) / -90f;

        var windDirectionDeltaSigned = (transform.rotation.eulerAngles.y - wind.WindDirection + 360) % 360 - 180;
        var windDirectionSign = Mathf.Sign(windDirectionDeltaSigned);
        var windDirectionDelta = 90 - Mathf.Abs(Mathf.Abs(windDirectionDeltaSigned) - 90);

        // wind.WindSpeed could be squared
        var windForce = windDirectionSign * Mathf.Sin(windDirectionDelta * Mathf.Deg2Rad) * dragPercentage * wind.WindSpeed * sailDragForce;

        var backForce = Mathf.Sin(transform.localRotation.eulerAngles.z * Mathf.Deg2Rad) * keelWeight;

        var totalForce = windForce - backForce;

        rollRotationSpeed += totalForce * Time.deltaTime;

        transform.localRotation *= Quaternion.AngleAxis(rollRotationSpeed * Time.deltaTime, Vector3.forward);

        rollRotationSpeed -= rollRotationSpeed * angularDeceleration * Time.deltaTime;
    }
}
