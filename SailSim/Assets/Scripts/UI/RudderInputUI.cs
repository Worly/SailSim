using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RudderInputUI : MonoBehaviour
{
    [SerializeField]
    public RudderInput rudderInput;

    [SerializeField]
    public Text rudderinputText;

    
    void Update()
    {
        rudderinputText.text=$"Rudder: {rudderInput.Rotation.ToString("0.0")}";

    }
}
