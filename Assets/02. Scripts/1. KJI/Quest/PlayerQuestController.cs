using UnityEngine;

public class PlayerQuestController : MonoBehaviour
{
    public float raycastDistance = 5f; // 레이캐스트 거리
    public LayerMask objectLayer; // 감지할 레이어
    private QuestCounter questCounter; // QuestCounter 스크립트 참조

    void Start()
    {
        questCounter = GetComponent<QuestCounter>(); // QuestCounter 스크립트 참조 가져오기
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 확인
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, raycastDistance, objectLayer))
            {
                // 레이캐스트가 오브젝트를 감지한 경우
                GameObject detectedObject = hit.collider.gameObject;

                // QuestCounter 스크립트에 오브젝트 감지 메서드 호출
                questCounter.IncreaseCount();
            }
        }
    }
}
