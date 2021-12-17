using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    public ScenarioSettings scenarioSettings;

    public float WindSpeed { get; private set; }
    public float WindDirection { get; private set; }

    public Vector3 WindDirectionVector
    {
        get => Quaternion.AngleAxis(WindDirection, Vector3.up) * Vector3.back;
    }

    public void Awake()
    {
        WindSpeed = scenarioSettings.windSpeed;
        WindDirection = scenarioSettings.windDirection;
    }

    public void Update()
    {
        // TODO: mijenjanje smjera vjetra kroz vrijeme
    }
}
