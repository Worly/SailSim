using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestSailPositionUI : MonoBehaviour
{
    [SerializeField]
    public ScenarioSettings scenarioSettings;

    [SerializeField]
    public BoatMovement boatMovement;

    [SerializeField]
    public SailRotation sail;

    [SerializeField]
    public Wind wind;

    private RectTransform rectTransform;

    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        if (!scenarioSettings.showBestSailPosition)
            image.enabled = false;
    }

    public void Update()
    {
        var boatWindAngle = boatMovement.GetBoatWindAngle();

        if (boatMovement.GetMaxSpeed(boatWindAngle) < 0.01)
            image.enabled = false;
        else if (scenarioSettings.showBestSailPosition)
            image.enabled = true;

        int offset;
        int sign;

        var sailWindAngle = (sail.transform.rotation.eulerAngles.y - wind.WindDirection + 360) % 360;
        if (sailWindAngle < 90)
        {
            offset = 0;
            sign = -1;
        }
        else if (sailWindAngle < 180)
        {
            offset = 180;
            sign = 1;
        }
        else if (sailWindAngle < 270)
        {
            offset = 180;
            sign = -1;
        }
        else
        {
            offset = 0;
            sign = 1;
        }

        var windAngle = -wind.WindDirection + offset;

        var angle = windAngle + boatMovement.GetBestSailAngle(boatWindAngle) * sign;

        rectTransform.localRotation = Quaternion.AngleAxis(angle + boatMovement.transform.rotation.eulerAngles.y, Vector3.forward);
    }
}
