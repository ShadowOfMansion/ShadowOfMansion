using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����: ���콺�� �Է��� �޾� ī�޶� ȸ����Ų��.
// �ʿ�Ӽ�: ���콺 �Է� X, Y, �ӵ�
// ����1. ������� ���콺 �Է��� �޴´�.
// ����2. ���콺 �Է¿� ���� ȸ�� ������ �����Ѵ�.
// ����3. ��ü�� ȸ����Ų��.
public class CamRotate : MonoBehaviour
{
    // �ʿ�Ӽ�: ���콺 �Է� X, Y, �ӵ�
    public float speed = 10f;
    float mx = 0;
    float my = 0;


    // Update is called once per frame
    void Update()
    {
        // ����1. ������� ���콺 �Է�(X, Y)�� �޴´�.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * speed * Time.deltaTime;
        my += mouseY * speed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        // ����2. ���콺 �Է¿� ���� ȸ�� ������ �����Ѵ�.
        Vector3 dir = new Vector3(-my, mx, 0);

        // ����3. ��ü�� ȸ����Ų��.
        // r = r0 + vt
        transform.eulerAngles = dir;
    }
}