using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    public float moveDuration = 2.0f; // �̵��ϴ� �� �ɸ��� �ð�

    private Vector3 initialPlayerPosition;
    private Vector3 initialEnemyPosition;
    private bool reachedInitialPosition = false;
    private bool movedToNewPosition = false;
    private float startTime;

    void Start()
    {
        initialPlayerPosition = player.transform.position;
        initialEnemyPosition = enemy.transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        if (!reachedInitialPosition)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // 0�� 1 ������ ���� ����

            player.transform.position = Vector3.Lerp(initialPlayerPosition, initialPlayerPosition + new Vector3(0.0f, 0.0f, 9.37f), t);
            enemy.transform.position = Vector3.Lerp(initialEnemyPosition, initialEnemyPosition + new Vector3(0.0f, 0.0f, 9.37f), t);

            if (t >= 1.0f) // �̵��� �Ϸ�Ǹ�
            {
                reachedInitialPosition = true;
                startTime = Time.time; // ���ο� ���� �ð� ����
            }
        }
        else if (!movedToNewPosition)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // 0�� 1 ������ ���� ����

            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(0f, 0.0f, 0.0f), t);
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, enemy.transform.position + new Vector3(0f, 0.0f, 0.0f), t);

            if (t >= 1.0f) // ���ο� ��ġ �̵��� �Ϸ�Ǹ�
            {
                movedToNewPosition = true;
            }
        }
    }
}
