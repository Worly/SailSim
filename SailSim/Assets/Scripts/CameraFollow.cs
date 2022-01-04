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

    [SerializeField]
    public float speedFactor;

    public void LateUpdate()
    {
        var positionDelta = (target.position + Quaternion.Euler(0, target.rotation.eulerAngles.y, 0) * targetOffset) - transform.position;

        transform.position += positionDelta * speedFactor * Time.deltaTime;

        transform.LookAt(target);

        transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
