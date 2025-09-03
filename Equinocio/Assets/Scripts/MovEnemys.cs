using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates 
{
    Idle, LookingFor, Chase
}


public class MovEnemys : MonoBehaviour
{
    EnemyStates states;
    NavMeshAgent agent;
    float waitTime = 2;
    [SerializeField] float visonAngle;
    [SerializeField] Transform player;
    [SerializeField] Transform[] patrolPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetState(EnemyStates.LookingFor);
    }

    // Update is called once per frame
    void Update()
    {
        Looking();
    }

    public void SetState(EnemyStates newState)
    {

    }

    IEnumerator Watting()
    {
        yield return new WaitForSeconds(waitTime);
        SetState(EnemyStates.LookingFor);
    }


    public void Looking()
    {
        if (!Physics.Linecast(transform.position, player.position))
        {
            SetState(EnemyStates.Chase);
        }
        else

        {
            if (!states.Equals(EnemyStates.Chase))
                return;

        }
    }

    
}
