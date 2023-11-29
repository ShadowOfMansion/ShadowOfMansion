using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ�: �̵��ӵ�
    public float speed = 10;

    // �ʿ�Ӽ�: ĳ���� ��Ʈ�ѷ�, �߷� ����, ���� �ӷ� ����, �����Ŀ�, ���� ���� ����
    CharacterController characterController;
    float gravity = -20f;
    float yVelocity = 0;
    public float jumpPower = 10;
    public bool isJumping = false;

    private void Start()
    {
        //characterController = GetComponent<CharacterController>();
    }


    
    void Update()
    {
        // ����1. ������� �Է��� �޴´�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ���� ���� ���̾��ٸ� ���� �� ���·� �ʱ�ȭ �ϰ� �ʹ�.
        if (isJumping && characterController.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;

            yVelocity = 0;
        }
        // �ٴڿ� ��� ���� ��, ���� �ӵ��� �ʱ�ȭ �ϰ� �ʹ�.
        /*else if (characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0;
        }*/

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        // ����2. �̵� ������ �����Ѵ�.
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);

        // 2-1. ĳ���� ���� �ӵ��� �߷��� �����ϰ� �ʹ�.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        // ����3. �̵� �ӵ��� ���� ���� �̵���Ų��.
        //transform.position += dir * speed * Time.deltaTime;

        // 2-2. ĳ���� ��Ʈ�ѷ��� ���� �̵���Ű�� �ʹ�.
        characterController.Move(dir * speed * Time.deltaTime);
    }
}