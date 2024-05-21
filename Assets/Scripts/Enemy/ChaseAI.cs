using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class ChaseAI : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    public Transform returnPoint;
    public float chaseDistance;
    public float giveUpDistance;
    public LayerMask obstacleLayer;
    private Animator animator;
    private Vector2 move;
    private Vector2 facingDirection = Vector2.down;
    private const string isWalking = "IsWalking";
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    private bool isChasing = false; // Flag para indicar se est� perseguindo o jogador

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        bool canSeePlayer = !Physics.Linecast(transform.position, player.transform.position, obstacleLayer);

        if (distanceToPlayer <= chaseDistance && canSeePlayer)
        {
            // Se estiver dentro da dist�ncia de persegui��o, come�a a persegui��o
            agent.SetDestination(player.transform.position);
            isChasing = true;
        }
        else if (isChasing && distanceToPlayer > giveUpDistance || !canSeePlayer)
        {
            // Se estava perseguindo mas saiu do alcance, para e retorna ao ponto de origem
            isChasing = false;
            agent.ResetPath();
        }

        // Atualiza a anima��o apenas se estiver perseguindo ou retornando ao ponto de origem
        if (isChasing || (returnPoint && !isChasing && distanceToPlayer > giveUpDistance))
        {
            move = new Vector2(agent.velocity.x, agent.velocity.y);
            bool isMoving = move != Vector2.zero;
            animator.SetBool(isWalking, isMoving);

            if (isMoving)
            {
                facingDirection = move.normalized;
                animator.SetFloat(horizontal, move.x);
                animator.SetFloat(vertical, move.y);
                animator.SetFloat(lastHorizontal, move.x);
                animator.SetFloat(lastVertical, move.y);
            }
        }
    }

}