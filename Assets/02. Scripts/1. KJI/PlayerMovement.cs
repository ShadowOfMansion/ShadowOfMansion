using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f; // 이동 속도

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // w -> 앞
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        // s -> 뒤
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        // 이동 방향 벡터를 정규화하여 속도와 방향을 분리
        moveDirection.Normalize();

        // 속도를 곱하여 움직임을 조절
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
