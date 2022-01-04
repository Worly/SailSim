using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontSailRotation : MonoBehaviour
{
    [SerializeField]
    public SailRotation sailRotation;

    [SerializeField]
    public float rotationWhenFullyLoose;

    public void Update()
    {
        var mainSailRotation = (sailRotation.transform.localRotation.eulerAngles.y + 180) % 360 - 180;

        var sailRotationPercentage = mainSailRotation / sailRotation.rotationWhenFullyLoose;

        transform.localRotation = Quaternion.AngleAxis(sailRotationPercentage * rotationWhenFullyLoose, Vector3.up);
    }
}
