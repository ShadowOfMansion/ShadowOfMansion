using UnityEngine;

public class PlayerQuestController : MonoBehaviour
{
    public float raycastDistance = 5f; // ����ĳ��Ʈ �Ÿ�
    public LayerMask objectLayer; // ������ ���̾�
    private QuestCounter questCounter; // QuestCounter ��ũ��Ʈ ����

    void Start()
    {
        questCounter = GetComponent<QuestCounter>(); // QuestCounter ��ũ��Ʈ ���� ��������
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� Ȯ��
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, raycastDistance, objectLayer))
            {
                // ����ĳ��Ʈ�� ������Ʈ�� ������ ���
                GameObject detectedObject = hit.collider.gameObject;

                // QuestCounter ��ũ��Ʈ�� ������Ʈ ���� �޼��� ȣ��
                questCounter.IncreaseCount();
            }
        }
    }
}
