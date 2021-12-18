using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    public Vector3 targetOffset;

    [SerializeField]
    public Vector3 rotationOffset;

    public void LateUpdate()
    {
        transform.position = target.position + Quaternion.Euler(0, target.rotation.eulerAngles.y, 0) * targetOffset;

        transform.LookAt(target);

        transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
