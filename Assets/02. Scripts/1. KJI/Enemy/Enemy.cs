using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // 플레이어의 위치를 저장하기 위한 변수
    public float detectionRange = 10f; // 플레이어를 감지하는 범위
    public float searchTime = 300f; // 5분 = 300초 (수색 시간)
    public float rampageDuration = 180f; // 3분 = 180초 (폭주 지속 시간)
    public float attackRange = 2f; // 플레이어를 공격할 수 있는 범위
    public Animator enemyAnimator; // 적 캐릭터의 애니메이터

    public AudioSource audioSource; // 소리를 재생하기 위한 오디오 소스
    public AudioClip idleSound; // Idle 상태의 소리
    public AudioClip chaseSound; // Chase 상태의 소리
    public AudioClip attackSound; // Attack 상태의 소리
    public AudioClip searchSound; // Search 상태의 소리
    public AudioClip rampageSound; // Rampage 상태의 소리

    private enum EnemyState
    {
        Idle,
        Chase,
        Search,
        Rampage,
        Attack
    } 

    private EnemyState currentState = EnemyState.Idle; // 적의 현재 상태
    private float timeSinceLastSighting = 0f; // 플레이어를 최근에 마지막으로 발견한 후 지난 시간
    private float rampageTimer = 0f; // 폭주 상태의 지속 시간을 측정하기 위한 타이머

    void Start()
    {
        
        enemyAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 각 상태에 따른 소리 재생
        if (currentState == EnemyState.Idle)
        {
            PlaySound(idleSound);
        }
        else if (currentState == EnemyState.Chase)
        {
            PlaySound(chaseSound);
        }
        else if (currentState == EnemyState.Attack)
        {
            PlaySound(attackSound);
        }
        else if (currentState == EnemyState.Search)
        {
            PlaySound(searchSound);
        }
        else if (currentState == EnemyState.Rampage)
        {
            PlaySound(rampageSound);
        }

        // 적 캐릭터의 상태 전환 및 행동 처리
        switch (currentState)
        {
            case EnemyState.Idle:
                // 플레이어가 일정 범위 내에 들어오면 추격 상태로 변경
                if (distanceToPlayer <= detectionRange)
                {
                    currentState = EnemyState.Chase;
                    print("상태전환: Idle -> Search");
                }
                break;

            case EnemyState.Chase:
                // 플레이어가 공격 범위 내에 들어오면 공격 상태로 변경, 범위를 벗어나면 수색 상태로 변경
                if (distanceToPlayer <= attackRange)
                {
                    currentState = EnemyState.Attack;
                    print("상태전환: Idle -> Attack");
                }
                else if (distanceToPlayer > detectionRange)
                {
                    currentState = EnemyState.Search;
                    timeSinceLastSighting = 0f;
                    print("상태전환: Attack -> Idle");
                }
                break;

            case EnemyState.Search:
                // 일정 시간이 지나면 폭주 상태로 변경, 플레이어를 다시 발견하면 추격 상태로 변경
                timeSinceLastSighting += Time.deltaTime;
                if (timeSinceLastSighting >= searchTime)
                {
                    currentState = EnemyState.Rampage;
                    rampageTimer = 0f;
                    print("상태전환:  Search -> Rampage ");

                }
                else if (distanceToPlayer <= detectionRange)
                {
                    currentState = EnemyState.Chase;
                    print("상태전환:  Rampage -> Search ");
                }
                break;

            case EnemyState.Rampage:
                // 일정 시간이 지나면 폭주 상태 종료, 플레이어를 다시 발견하면 추격 상태로 변경
                rampageTimer += Time.deltaTime;
                if (rampageTimer >= rampageDuration)
                {
                    currentState = EnemyState.Idle;
                    print("상태전환:  Rampage -> Idle ");
                }
                else if (distanceToPlayer <= detectionRange)
                {
                    currentState = EnemyState.Chase;
                    print("상태전환:  Rampage -> Chase ");
                }
                break;

            case EnemyState.Attack:
                // 플레이어를 공격하는 코드
                break;
        }
    }

    // AudioClip을 받아 해당 소리를 재생하는 함수
    void PlaySound(AudioClip clip)
    {
        if (!audioSource.isPlaying || audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
