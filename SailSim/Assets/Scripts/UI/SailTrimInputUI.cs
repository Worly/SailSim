using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailTrimInputUI : MonoBehaviour
{
    [SerializeField]
    public SailTrimInput sailtriminput;

    public Slider slider;

    
    void Update()
    {
        slider.value=sailtriminput.Tightness;
    }

}
