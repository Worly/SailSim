using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailTopDownUI : MonoBehaviour
{
    [SerializeField]
    public Transform sailTransform;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.localRotation = Quaternion.AngleAxis(-sailTransform.localRotation.eulerAngles.y, Vector3.forward);
    }
}
