using System;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    public Transform focus = default;

    public Vector3 focusOffset;

    [SerializeField, Range(1f, 200f)]
    public float distance = 5f;

    public float rotationSpeed = 5f;
    
    // 事件函数，在Update后调用
    void LateUpdate()
    {
        Vector3 focusPosition = focus.position + focusOffset;
        transform.position = focusPosition - transform.forward * distance;
        transform.rotation = Quaternion.Euler(45, rotationSpeed * Time.time, 0);
    }

}
