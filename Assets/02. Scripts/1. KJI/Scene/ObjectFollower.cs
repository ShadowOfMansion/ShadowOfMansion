using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    public float moveDuration = 2.0f; // 이동하는 데 걸리는 시간

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
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // 0과 1 사이의 값을 유지

            player.transform.position = Vector3.Lerp(initialPlayerPosition, initialPlayerPosition + new Vector3(0.0f, 0.0f, 9.37f), t);
            enemy.transform.position = Vector3.Lerp(initialEnemyPosition, initialEnemyPosition + new Vector3(0.0f, 0.0f, 9.37f), t);

            if (t >= 1.0f) // 이동이 완료되면
            {
                reachedInitialPosition = true;
                startTime = Time.time; // 새로운 시작 시간 설정
            }
        }
        else if (!movedToNewPosition)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration); // 0과 1 사이의 값을 유지

            player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + new Vector3(0f, 0.0f, 0.0f), t);
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, enemy.transform.position + new Vector3(0f, 0.0f, 0.0f), t);

            if (t >= 1.0f) // 새로운 위치 이동이 완료되면
            {
                movedToNewPosition = true;
            }
        }
    }
}
