using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private float chaseTimer;

    private GameObject targetPlayer;
    private PlayerStatus playerStatus;


    public ChaseNode(Transform _target, NavMeshAgent _agent, EnemyAI _enemy)
    {
        this.target = _target;
        this.agent = _agent;
        this.enemmy = _enemy;
        chaseTimer = 0f;
    }
    public override NodeState Evaluate()
    {
        enemmy.SetColor(Color.red);
        
        // var _distance = Vector3.Distance(target.position, agent.transform.position);

        targetPlayer = EnemyAI.targetedPlayer;
        
        playerStatus = targetPlayer.GetComponent<PlayerStatus>();

        // if (_distance > 0.1f)
        // {
        //     agent.isStopped = false;
        //     agent.SetDestination(target.position);
        //     return NodeState.RUNNING;
        // }

        if (targetPlayer != null)
        {
            agent.isStopped = false;
            agent.SetDestination(targetPlayer.transform.position);
            return NodeState.RUNNING;
        }

        return NodeState.SUCCESS;
    }

    // private void ChasingTime()
    // {
    //     agent.isStopped = false;
    //     agent.SetDestination(target.position);
    //     Debug.Log($"Countdown before stop chase");
    //     agent.isStopped = true;
    // }
}
