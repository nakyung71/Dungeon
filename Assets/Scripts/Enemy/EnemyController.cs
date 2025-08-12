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

        //�����ϰ������
        //�÷��̾ safezone�� ���� (�� ���Ͱ� ���ٺҰ��� ������ ����>���� �׳� �������·� ���ư��� ������)
        //������: ���� �׷��� ���� �����϶�� ����� ������ �÷��̾ �þ� �ȿ� �����ִ� ���°� �����Ǵϱ� �ذ��������.
        //�ذ�å 1) ª�� �ð����� �þ߸� ���δ�
        //�ذ�å 2) �ƿ� �÷��̾ �i�� ���� ��ü�� �ٲ۴�
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
        Debug.Log("���� ���� ���");
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
