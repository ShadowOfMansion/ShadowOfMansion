using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // �ʿ�Ӽ�: ���콺 �Է� X, Y, �ӵ�
    public float speed = 200f;

    // Update is called once per frame
    void Update()
    {
        // ����1. ������� ���콺 �Է�(X, Y)�� �޴´�.
        float mouseX = Input.GetAxis("Mouse X");

        // ����2. ���콺 �Է¿� ���� ȸ�� ������ �����Ѵ�.
        Vector3 dir = new Vector3(0, mouseX, 0);

        // ����3. ��ü�� ȸ����Ų��.
        // r = r0 + vt
        transform.eulerAngles = transform.eulerAngles + dir * speed * Time.deltaTime;
    }
}