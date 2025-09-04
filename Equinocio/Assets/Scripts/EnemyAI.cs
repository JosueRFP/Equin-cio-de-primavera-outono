using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public interface IMonstable
{
    void MonsterAnimationChange(MonsterStates states);
}

public enum MonsterStates
{
    Wait, Patrol, Chase, Search, Attack
}

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI instance;

    MonsterStates state;
    NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] Transform[] patrolPoints;
    [Min(1)][SerializeField] private float waitTime;

    [Header("Shooting Settings")]
    [SerializeField] private bool canShoot = false; 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletSpeed = 15f;

    private float nextFireTime;

    private AnimatorController monsterAnimator;

    void Start()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
        monsterAnimator = GetComponent<AnimatorController>();

        SetState(MonsterStates.Patrol);
    }

    void Update()
    {
        Looking();

        switch (state)
        {
            case MonsterStates.Wait:
                break;

            case MonsterStates.Patrol:
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    SetState(MonsterStates.Wait);
                }
                break;

            case MonsterStates.Chase:
                agent.SetDestination(player.position);

                if (canShoot && Vector3.Distance(transform.position, player.position) < 10f)
                {
                    SetState(MonsterStates.Attack);
                }
                break;

            case MonsterStates.Search:
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    SetState(MonsterStates.Wait);
                }
                break;

            case MonsterStates.Attack:
                if (canShoot) 
                    AttackPlayer();
                else
                    SetState(MonsterStates.Chase);
                break;
        }
    }

    public void SetState(MonsterStates newState)
    {
        monsterAnimator?.MonsterAnimationChange(newState);

        switch (newState)
        {
            case MonsterStates.Wait:
                StartCoroutine(Waiting());
                break;

            case MonsterStates.Patrol:
                agent.isStopped = false;
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
                break;

            case MonsterStates.Chase:
                agent.isStopped = false;
                break;

            case MonsterStates.Search:
                agent.isStopped = false;
                break;

            case MonsterStates.Attack:
                agent.isStopped = true;
                break;
        }

        state = newState;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        SetState(MonsterStates.Patrol);
    }

    public void Looking()
    {
        Debug.DrawLine(transform.position, player.position, Color.red);

        if (!Physics.Linecast(transform.position, player.position))
        {
            if (state != MonsterStates.Attack)
                SetState(MonsterStates.Chase);

            print("Vejo");
        }
        else
        {
            print("Não vejo");
            if (!state.Equals(MonsterStates.Chase) && !state.Equals(MonsterStates.Attack))
                return;

            SetState(MonsterStates.Search);
        }
    }

    private void AttackPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }

        if (Vector3.Distance(transform.position, player.position) > 15f)
        {
            SetState(MonsterStates.Chase);
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, 5f);
    }
}

