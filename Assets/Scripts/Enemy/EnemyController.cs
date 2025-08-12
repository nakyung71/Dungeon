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

    //���̴ٴϱ�
    public Vector3 walkPoint;
    private bool isWalkPointSet;
    public float walkPointRange;


    //����
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public float attackDamage;

    //�÷��̾ �þ� �ȿ� �����?
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Start()
    {
        player=PlayerManager.instance.player.transform;
        agent=GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,playerLayerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayerMask);

        

        if(!playerInSightRange&&!playerInAttackRange)
        {
            Patroling();
        }
        else if(playerInSightRange&&!playerInAttackRange)
        {
            
            
            if (agent.pathStatus == NavMeshPathStatus.PathPartial || agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                Debug.Log("���� ���� ����/�÷��̾� �������� �Լ�, ��� ��Ž��");
                Patroling();
                return;
            }
            ChasePlayer();

        }
        else if(playerInAttackRange&&playerInSightRange)
        {
            AttackPlayer();
        }
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
            //���⿡ � ����
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
