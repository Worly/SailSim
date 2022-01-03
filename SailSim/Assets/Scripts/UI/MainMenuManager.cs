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
    public Toggle showBestSailPositionToggle;

    public void Awake()
    {
        showBestSailPositionToggle.isOn = scenarioSettings.showBestSailPosition;
    }

    public void ToggleShowBestSailPosition()
    {
        scenarioSettings.showBestSailPosition = showBestSailPositionToggle.isOn;
    }

    public void StartSimulation()
    {
        SceneManager.LoadScene("Simulation");
    }
}
