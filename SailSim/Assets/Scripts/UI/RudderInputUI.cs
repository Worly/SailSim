using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RudderInputUI : MonoBehaviour
{
    [SerializeField]
    public RudderInput rudderInput;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.localRotation = Quaternion.AngleAxis(-rudderInput.Rotation, Vector3.forward);
    }
}