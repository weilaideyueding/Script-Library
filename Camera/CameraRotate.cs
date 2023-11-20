using System;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    public Transform focus = default;
    
    public Vector3 focusOffset;
    
    [Space(5)]
    [Range(-180f, 180f)]
    public float angle = 45f;

    [Range(1f, 100f)]
    public float distance = 5f;

    [Space(5)]
    [Range(1, 5)]
    public float transformLerp = 1f;
    public float rotationSpeed = 5f;
    
    // 事件函数，在Update后调用
    void LateUpdate()
    {
        // 平滑移动
        Vector3 focusPosition = focus.position + focusOffset;
        transform.position = Vector3.Lerp(transform.position, focusPosition - transform.forward * distance, Time.deltaTime * transformLerp);
        
        // 平滑旋转
        Quaternion targetRotation = Quaternion.Euler(angle, rotationSpeed * Time.time, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

}
