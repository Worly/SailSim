using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderInput : MonoBehaviour
{
    [SerializeField]
    public KeyCode leftKey;

    [SerializeField]
    public KeyCode rightKey;

    [SerializeField]
    public float rudderSensitivity;

    [SerializeField]
    public int rudderMaxAngle;

    [SerializeField]
    public int rudderReturnFactor;

    private float rotation = 0;

    public float Rotation
    {
        get => rotation;
        private set
        {
            if (value > rudderMaxAngle)
                rotation = rudderMaxAngle;
            else if (value < -rudderMaxAngle)
                rotation = -rudderMaxAngle;
            else
                rotation = value;
        }
    }

    void Update()
    {
        float shift = 1 / rudderSensitivity * rudderMaxAngle * Time.deltaTime;

        if (-shift * rudderReturnFactor < Rotation && Rotation < shift * rudderReturnFactor
            && !Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            Rotation = 0;

        else if (Rotation < 0 && !Input.GetKey(leftKey))
            Rotation += shift * rudderReturnFactor;

        else if (Rotation > 0 && !Input.GetKey(rightKey))
            Rotation -= shift * rudderReturnFactor;

        else if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            Rotation -= shift;

        else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
            Rotation += shift;    
    }
}
