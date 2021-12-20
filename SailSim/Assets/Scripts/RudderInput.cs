using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderInput : MonoBehaviour
{
    [SerializeField]
    public KeyCode left;

    [SerializeField]
    public KeyCode right;

    [SerializeField] public float Ruddervalue; 



    void Update()
    {
        
        if (Input.GetKey(left))
        {
            Ruddervalue-=0.005f;       
        }
        
        else if (Input.GetKey(right))
        {
             Ruddervalue+=0.005f;
                
        }
        if (Ruddervalue<-1)
            {
                Ruddervalue=-1;
            }
        else if (Ruddervalue>1)
            {
                Ruddervalue=1;
            }
         transform.localRotation*=Quaternion.AngleAxis(Ruddervalue/10,Vector3.up);
    }
}
