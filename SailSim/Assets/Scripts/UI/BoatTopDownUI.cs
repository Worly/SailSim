using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTopDownUI : MonoBehaviour
{
    [SerializeField]
    public Transform boatTransform;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.localRotation = Quaternion.AngleAxis(-boatTransform.rotation.eulerAngles.y, Vector3.forward);
    }
}
