using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float turnSmooht;
    public float pivotSpeed;
    public float YRotationSpeed;
    public float XRotationSpeed;
    public float minAngel;
    public float maxAngel;
    public float normalX;
    public float normalZ;
    public float aimZ;
    public float aimX;
    public float normalY;
    
}
