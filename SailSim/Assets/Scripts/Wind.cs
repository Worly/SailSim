using Crest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    public ScenarioSettings scenarioSettings;

    [SerializeField]
    public ShapeGerstnerBatched shapeGerstnerBatched;

    [SerializeField]
    public float minWindSpeed;

    [SerializeField]
    public float maxWindSpeed;

    public float WindSpeed { get; private set; }
    public float WindDirection { get; private set; }

    public Vector3 WindDirectionVector
    {
        get => Quaternion.AngleAxis(WindDirection, Vector3.up) * Vector3.back;
    }

    public void Awake()
    {
        WindSpeed = scenarioSettings.windSpeed;
        WindDirection = scenarioSettings.windDirection % 360;

        //shapeGerstnerBatched._windDirectionAngle = WindDirection;

        if (maxWindSpeed < WindSpeed)
            maxWindSpeed = WindSpeed;
        else if (minWindSpeed > WindSpeed)
            minWindSpeed = WindSpeed;

        shapeGerstnerBatched._weight =  (WindSpeed - minWindSpeed)
                                        / (maxWindSpeed - minWindSpeed);
    }

    public void Update()
    {
        // TODO: mijenjanje smjera vjetra kroz vrijeme
    }
}
