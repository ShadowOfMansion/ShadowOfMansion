using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; // 마우스 감도

    private float rotationX = 0.0f;

    void Update()
    {
        // 마우스 입력 받기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전 - 플레이어의 좌우 회전에 반응
        transform.Rotate(Vector3.up, mouseX * sensitivity);

        // 수직 회전 - 카메라의 상하 회전에 반응
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f); // 상하 회전 각도 제한

        // 상하 회전 적용
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
