using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject TargetToFollow;
    public bool IsFollowing = true;
    public float CameraOffset = -10.0f;

    public void Update() 
    {
        if (IsFollowing && TargetToFollow != null) 
        {
            Vector3 newPosition = TargetToFollow.transform.position;
            newPosition.x = 0.0f;       
            newPosition.z = CameraOffset; 
            transform.position = newPosition;
        }        
    }
}
