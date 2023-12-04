using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn = false;
    public Light flashlight;

    void Start()
    {
        // 손전등에 연결된 Light 컴포넌트 찾기
        //flashlight = GetComponent<Light>();

        // 손전등 초기 상태: 꺼짐
        flashlight.intensity = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;

            if (isOn)
            {
                // 손전등을 켤 때 빛의 강도를 조절하여 켜진 느낌을 줌
                flashlight.intensity = 1.5f;
            }
            else
            {
                // 손전등을 끌 때 빛의 강도를 0으로 하여 꺼진 느낌을 줌
                flashlight.intensity = 0f;
            }
        }
    }
}
