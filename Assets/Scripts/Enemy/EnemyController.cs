using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public LayerMask playerLayerMask;
    public LayerMask groundLayerMask;

    //돌이다니기
    public Vector3 walkPoint;
    private bool isWalkPointSet;
    public float walkPointRange;


    //공격
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public float attackDamage;

    //플레이어가 시야 안에 들었나?
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;


    private float previousSightRange;
    private float previousAttackRange;
    
    private void Start()
    {
        player=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,playerLayerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayerMask);

        //구현하고싶은거
        //플레이어가 safezone에 들어가면 (즉 몬스터가 접근불가한 구역에 진입>이후 그냥 정찰상태로 돌아가면 좋겠음)
        //문제점: 만약 그럴때 내가 정찰하라고 명령을 내려도 플레이어가 시야 안에 들어와있는 상태가 유지되니까 해결되지않음.
        //해결책 1) 짧은 시간동안 시야를 줄인다
        //해결책 2) 아예 플레이어를 쫒는 조건 자체를 바꾼다
        if(!playerInSightRange&&!playerInAttackRange)
        {
            Patroling();
        }
        else if(playerInSightRange&&!playerInAttackRange)
        {
            if(agent.path.status== NavMeshPathStatus.PathPartial ||agent.path.status== NavMeshPathStatus.PathInvalid)
            {
                StartCoroutine(ForcePatrolMode());
            }
            ChasePlayer();

        }
        else if(playerInAttackRange&&playerInSightRange)
        {
            AttackPlayer();
        }

       
        
    }

    IEnumerator ForcePatrolMode()
    {
        Debug.Log("강제 정찰 모드");
        previousSightRange = sightRange;
        previousAttackRange = attackRange;
        sightRange = 0f;
        attackRange = 0f;
        yield return new WaitForSeconds(3f);
        sightRange = previousSightRange;
        attackRange = previousAttackRange;
    }

   

    private void Patroling()
    {
        if(!isWalkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude<1f)
        {
            isWalkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ=Random.Range(-walkPointRange,walkPointRange);
        float randomX=Random.Range(-walkPointRange,walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint,-transform.up,2f,groundLayerMask))
        {
            isWalkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //여기에 어떤 공격
            PlayerManager.instance.player.ChangeHealth(-attackDamage);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked=false;
    }


}
