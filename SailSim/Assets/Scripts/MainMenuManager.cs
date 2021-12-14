using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    public ScenarioSettings scenarioSettings;

    [SerializeField]
    public Toggle lowWindSpeedToggle;
    [SerializeField]
    public float lowWindSpeed;

    [SerializeField]
    public Toggle midWindSpeedToggle;
    [SerializeField]
    public float midWindSpeed;

    [SerializeField]
    public Toggle highWindSpeedToggle;
    [SerializeField]
    public float highWindSpeed;

    public void Awake()
    {
        if (scenarioSettings.windSpeed == lowWindSpeed)
            lowWindSpeedToggle.isOn = true;
        else if (scenarioSettings.windSpeed == midWindSpeed)
            midWindSpeedToggle.isOn = true;
        else if (scenarioSettings.windSpeed == highWindSpeed)
            highWindSpeedToggle.isOn = true;
        else
        {
            scenarioSettings.windSpeed = midWindSpeed;
            midWindSpeedToggle.isOn = true;
        }
    }

    public void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn == false)
        {
            if (lowWindSpeedToggle.isOn == midWindSpeedToggle.isOn == highWindSpeedToggle.isOn == false)
                toggle.isOn = true;

            return;
        }

        if (toggle == lowWindSpeedToggle)
        {
            scenarioSettings.windSpeed = lowWindSpeed;
            midWindSpeedToggle.isOn = false;
            highWindSpeedToggle.isOn = false;
        }
        else if (toggle == midWindSpeedToggle)
        {
            scenarioSettings.windSpeed = midWindSpeed;
            lowWindSpeedToggle.isOn = false;
            highWindSpeedToggle.isOn = false;
        }
        else if (toggle == highWindSpeedToggle)
        {
            scenarioSettings.windSpeed = highWindSpeed;
            lowWindSpeedToggle.isOn = false;
            midWindSpeedToggle.isOn = false;
        }
    }

    public void StartSimulation()
    {
        SceneManager.LoadScene("Simulation");
    }
}
