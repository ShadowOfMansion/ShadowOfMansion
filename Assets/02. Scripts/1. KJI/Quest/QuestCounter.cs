using UnityEngine;
using TMPro;

public class QuestCounter : MonoBehaviour
{
    public TMP_Text countText; // TMP TextMeshPro �ؽ�Ʈ
    public GameObject[] objectsArray;
    public int totalObjects = 18; // �� ������Ʈ ����

    private int collectedObjects = 0; // ȹ���� ������Ʈ ����

    void Start()
    {
        UpdateCountText();
    }

    // ������Ʈ ī��Ʈ ���� �޼���
    public void IncreaseCount()
    {
        collectedObjects++; // ������Ʈ ī��Ʈ ����
        UpdateCountText(); // UI �ؽ�Ʈ ������Ʈ

        if (collectedObjects >= totalObjects)
        {
            // ��� ������Ʈ�� �������� �� ������ �۾�
            Debug.Log("��� ������Ʈ�� ã�ҽ��ϴ�!");
        }
    }

    void UpdateCountText()
    {
        countText.text = $"Collected: {collectedObjects}/{totalObjects}"; // TMP TextMeshPro �ؽ�Ʈ ������Ʈ
    }
}
