using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn = false;
    public Light flashlight;

    void Start()
    {
        // ����� ����� Light ������Ʈ ã��
        //flashlight = GetComponent<Light>();

        // ������ �ʱ� ����: ����
        flashlight.intensity = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;

            if (isOn)
            {
                // �������� �� �� ���� ������ �����Ͽ� ���� ������ ��
                flashlight.intensity = 1.5f;
            }
            else
            {
                // �������� �� �� ���� ������ 0���� �Ͽ� ���� ������ ��
                flashlight.intensity = 0f;
            }
        }
    }
}
