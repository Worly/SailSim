using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArrowUI : MonoBehaviour
{
    [SerializeField]
    public Wind wind;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.localRotation = Quaternion.AngleAxis(180 - wind.WindDirection, Vector3.forward);
    }
}
