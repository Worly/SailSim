using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailTrimInput : MonoBehaviour
{
    [SerializeField]
    public KeyCode looseKey;

    [SerializeField]
    public KeyCode tightenKey;

    [SerializeField]
    public float tightenSpeed;

    private float tightness = 1;
    /// <summary>
    /// 0 if fully loose, 1 if fully tight
    /// </summary>
    public float Tightness
    {
        get => tightness;
        private set
        {
            if (value > 1)
                tightness = 1;
            else if (value < 0)
                tightness = 0;
            else
                tightness = value;
        }
    }

    void Update()
    {
        if (Input.GetKey(looseKey))
            Tightness -= tightenSpeed * Time.deltaTime;

        if (Input.GetKey(tightenKey))
            Tightness += tightenSpeed * Time.deltaTime;
    }
}
