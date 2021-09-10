using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    
    

    private Vector3 mousPosition;
    public static InputController RefCamera;

     public  Vector3 _mousPosition { get { return mousPosition; } }

    void Awake()
    {
        if (RefCamera == null)
        {
            RefCamera = this;
        }
        
    }
     
    
    
    void Update()
    {
        mousPosition = Input.mousePosition;
    }
}
