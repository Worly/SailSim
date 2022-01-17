using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField]
    public SailRotation sail;

    [SerializeField]
    public Wind wind;

    [Tooltip("Za dani kut izmedu vjetra i broda, daje vrijednost maksimalne brzine koju brod moze postici")]
    [Curve(0, 0, 180, 2)]
    [SerializeField]
    public AnimationCurve maxSpeedCurve;

    [Tooltip("Za dani kut izmedu vjetra i broda, daje vrijednost najboljeg kuta izmedu jedra i vjetra")]
    [Curve(0, 0, 180, 90)]
    [SerializeField]
    public AnimationCurve bestSailAngleCurve;

    [Tooltip("Za danu gresku u kutu jedra za razliku od najboljeg kuta, daje vrijednost izmedu 0 i 1")]
    [Curve(0, 0, 180, 1)]
    [SerializeField]
    public AnimationCurve trimmingCurve;

    [SerializeField]
    public float accelerationFactor;

    public float CurrentSpeed { get; private set; } = 0;

    public bool isDownWind()
    {
        float sailWindFullAngle = (sail.transform.rotation.eulerAngles.y - wind.WindDirection + 360) % 360;
        float boatWindFullAngle = (transform.rotation.eulerAngles.y - wind.WindDirection + 360 + 180) % 360;
        return sailWindFullAngle < 180 && boatWindFullAngle < 180 || sailWindFullAngle > 180 && boatWindFullAngle > 180;            
    }

    public float GetBoatWindAngle()
    {
        return Mathf.Abs((transform.rotation.eulerAngles.y - wind.WindDirection + 360 + 180) % 360 - 180);
    }

    public float GetBestSailAngle(float boatWindAngle)
    {
        if (isDownWind())
            return boatWindAngle - 105;
        else
            return bestSailAngleCurve.Evaluate(boatWindAngle);
    }

    public float GetMaxSpeed(float boatWindAngle)
    {
        return maxSpeedCurve.Evaluate(boatWindAngle);
    }

    public void Update()
    {
        var sailWindAngleUpWind = Mathf.Abs((sail.transform.rotation.eulerAngles.y - wind.WindDirection + 360 + 180) % 360 - 180);
        var sailWindAngleDownWind = Mathf.Abs((sail.transform.rotation.eulerAngles.y - wind.WindDirection + 360) % 360 - 180);

        var sailWindAngle = isDownWind() ? sailWindAngleDownWind : sailWindAngleUpWind;

        var boatWindAngle = GetBoatWindAngle();

        var bestSailAngle = GetBestSailAngle(boatWindAngle);

        var angleDelta = Mathf.Abs(bestSailAngle - sailWindAngle);

        var maxSpeed = GetMaxSpeed(boatWindAngle) * trimmingCurve.Evaluate(angleDelta) * wind.WindSpeed;

        var speedDelta = maxSpeed - CurrentSpeed;

        CurrentSpeed += speedDelta * accelerationFactor * Time.deltaTime;

        transform.position += transform.forward * CurrentSpeed * Time.deltaTime;
    }
}
