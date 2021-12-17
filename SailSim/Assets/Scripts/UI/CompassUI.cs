using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUI : MonoBehaviour
{
    [SerializeField]
    public RectTransform compass;

    [SerializeField]
    public Wind wind;

    [SerializeField]
    public Camera mainCamera;

    public void Update()
    {
        var rotation = mainCamera.transform.rotation.eulerAngles.y - wind.WindDirection;
        compass.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
