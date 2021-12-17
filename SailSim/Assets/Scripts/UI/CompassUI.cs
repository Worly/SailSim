using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassUI : MonoBehaviour
{
    [SerializeField]
    public RectTransform compass;

    [SerializeField]
    public Camera mainCamera;

    public void Update()
    {
        var rotation = mainCamera.transform.rotation.eulerAngles.y;
        compass.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
    }
}
