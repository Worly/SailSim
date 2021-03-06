using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenario settings", menuName = "ScriptableObjects/Scenario settings")]
public class ScenarioSettings : ScriptableObject
{
    public bool showBestSailPosition;
    public float windSpeed;
    public float windDirection;
}
