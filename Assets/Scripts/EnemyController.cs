using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;

    public float detectionRange = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // 開始0秒でWanderを発動、以後は5秒ごと
        InvokeRepeating("Wander", 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Wander()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        // insideUnitSphereは周辺半径1の中からランダムで座標を選ぶ
        if (!agent.isStopped)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * detectionRange;
            // 上下のランダム値は無視して、そのとき敵のいた高さに据え置き
            randomPos.y = transform.position.y;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, detectionRange, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }
}
