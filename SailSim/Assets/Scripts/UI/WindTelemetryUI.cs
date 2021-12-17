using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindTelemetryUI : MonoBehaviour
{
    [SerializeField]
    public Wind wind;

    [SerializeField]
    public Text windSpeedText;

    public void Update()
    {
        windSpeedText.text = $"Wind speed: {wind.WindSpeed.ToString("0.0")} m/s";
    }
}
