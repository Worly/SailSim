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
    public float RotationSpeed;

    private float rotation = 0;
    /// <summary>
    /// -1 to 1
    /// </summary>
    public float Rotation
    {
        get => rotation;
        private set
        {
            if (value > 1)
                rotation = 1;
            else if (value < -1)
                rotation = -1;
            else
                rotation = value;
        }
    }

    void Update()
    {
        if (Input.GetKey(leftKey))
            Rotation -= RotationSpeed * Time.deltaTime;
        else if (Input.GetKey(rightKey))
            Rotation += RotationSpeed * Time.deltaTime;
        else
        {
            if (Rotation > 0)
                Rotation -= RotationSpeed * Time.deltaTime;
            else if (Rotation < 0)
                Rotation += RotationSpeed * Time.deltaTime;
        }
            

    }
}
