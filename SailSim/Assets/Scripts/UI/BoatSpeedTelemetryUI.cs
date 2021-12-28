using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatSpeedTelemetryUI : MonoBehaviour
{
    [SerializeField]
    public BoatMovement boatMovement;

    [SerializeField]
    public Text windSpeedText;

    public void Update()
    {
        windSpeedText.text = $"Boat speed: {boatMovement.CurrentSpeed.ToString("0.0")} m/s";
    }
}
