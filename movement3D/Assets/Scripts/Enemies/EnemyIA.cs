using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public bool boosEnemy;
    public SpawnManager spawnManager;
    public NavMeshAgent agent;
    public Transform player1;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator anim;
    public float health;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Attacking")]
    public Transform FireStart;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public soundManager soundManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player1 = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 0f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player1.position);
        if (boosEnemy == true)
        {
            anim.SetBool("IsWalking", true);
            agent.SetDestination(player1.position);
        }
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player1);


        if (!alreadyAttacked)
        {
            anim.SetTrigger("Attack");
            ///Attack code here
            Invoke("Shoot", 0.3f);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        if (boosEnemy == true)
        {
            anim.SetBool("IsWalking", false);
            agent.SetDestination(transform.position);

            transform.LookAt(player1);


            if (!alreadyAttacked)
            {
                anim.SetTrigger("Attack");
                ///Attack code here
                Invoke("Shoot", 0.3f);
                ///End of attack code

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        if (boosEnemy)
        {
            anim.SetTrigger("DamageHit");
            health -= damage;
            if (health <= 0) anim.SetTrigger("Death");
        }
        anim.SetTrigger("DamageHit");
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            Invoke(nameof(DestroyEnemy), 1.5f);
        }
    }
    private void DestroyEnemy()
    {
        spawnManager.Deathcount += 1;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    public void Shoot()
    {
        if(boosEnemy)soundManager.Instance.Play(6);
        if (boosEnemy == false)soundManager.Instance.Play(5);
        Instantiate(projectile, FireStart.position, FireStart.rotation);
    }
}
