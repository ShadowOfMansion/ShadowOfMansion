using UnityEngine;
using TMPro;

public class QuestCounter : MonoBehaviour
{
    public TMP_Text countText; // TMP TextMeshPro 텍스트
    public GameObject[] objectsArray;
    public int totalObjects = 18; // 총 오브젝트 개수

    private int collectedObjects = 0; // 획득한 오브젝트 개수

    void Start()
    {
        UpdateCountText();
    }

    // 오브젝트 카운트 증가 메서드
    public void IncreaseCount()
    {
        collectedObjects++; // 오브젝트 카운트 증가
        UpdateCountText(); // UI 텍스트 업데이트

        if (collectedObjects >= totalObjects)
        {
            // 모든 오브젝트를 수집했을 때 수행할 작업
            Debug.Log("모든 오브젝트를 찾았습니다!");
        }
    }

    void UpdateCountText()
    {
        countText.text = $"Collected: {collectedObjects}/{totalObjects}"; // TMP TextMeshPro 텍스트 업데이트
    }
}
