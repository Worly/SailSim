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
        var boatWindFullAngle = boatMovement.GetBoatWindFullAngle();

        if (boatMovement.GetMaxSpeed(boatWindAngle) < 0.01)
            image.enabled = false;
        else if (scenarioSettings.showBestSailPosition)
            image.enabled = true;

        int offset;
        int sign;

        var sailWindAngle = boatMovement.GetSailWindFullAngle();

        if (sailWindAngle < 90)
        {
            offset = 0;
            sign = -1;
        }
        else if (sailWindAngle < 180)
        {
            offset = 180;
            sign = 1;
            if (255 <= boatWindFullAngle && boatWindFullAngle < 345)
            {
                offset = 180 - offset;
                sign = -1 * sign;
            }
        }
        else if (sailWindAngle < 270)
        {
            offset = 180;
            sign = -1;
            if (15 <= boatWindFullAngle && boatWindFullAngle < 105)
            {
                offset = 180 - offset;
                sign = -1 * sign;
            }
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
