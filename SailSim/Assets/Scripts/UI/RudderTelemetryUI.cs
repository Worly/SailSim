using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RudderTelemetryUI : MonoBehaviour
{
    [SerializeField]
    public RudderInput rudderInput;

    [SerializeField]
    public Text rudderinputText;

    void Update()
    {
        rudderinputText.text = $"Rudder rotation: {rudderInput.Rotation.ToString("0.0")}°";
    }
}
